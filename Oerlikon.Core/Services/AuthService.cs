using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Oerlikon.Core.Commons;
using Oerlikon.Core.Databases;
using Oerlikon.Core.Interfaces;
using Oerlikon.Core.Models.Users;

namespace Oerlikon.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IAppSetting _appSetting;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public AuthService(DatabaseContext dbContext, IAppSetting appSetting)
        {
            _dbContext = dbContext;
            _appSetting = appSetting;
        }

        public async Task<UserLoginResponse> Login(UserLoginRequest request)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email && x.Status == Core.Constants.UserStatus.Active);
            if (user == null)
                throw new Core.Exceptions.AuthException("email or password is wrong");
            var hashedPassword = Commons.SecurityHelper.HashUsingSalt(request.Password, user.Salt, 10101, user.Salt.Length);
            if (user.HashedPassword != hashedPassword)
                throw new Core.Exceptions.AuthException("email or password is wrong");
            var claims = new[]
            {
                new Claim("sub", user.Name),
                new Claim("uid", user.UID.ToString()),
                new Claim("email",user.Email),

            };
            var expiredAccessToken = DateTimeHelper.GetCurrentTime().AddHours(7);

            var accessToken = CreateToken(claims, expiredAccessToken);
            return new UserLoginResponse
            {
                AccessToken = accessToken,
                UserUID = user.UID
                

            };
        }

        private string CreateToken(Claim[] claims, DateTime expiredAt)
        {
            var secret = Encoding.ASCII.GetBytes(_appSetting.JwtSecretKey);

            var jwtToken = new JwtSecurityToken(
             _appSetting.JwtIssuer,
             null,
             claims,
             expires: expiredAt,
             signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return accessToken;
        }
    }
}
