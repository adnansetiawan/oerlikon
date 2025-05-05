using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Oerlikon.Core.Databases;
using Oerlikon.Core.Interfaces;
using Oerlikon.Core.Models.Users;

namespace Oerlikon.Core.Services
{
    public class UserRegisterService : IUserRegisterService
    {
        private readonly DatabaseContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public UserRegisterService(DatabaseContext dbContext) 
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<UserRegisterResponse> Register(UserRegisterRequest request)
        {
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email && x.Status == Core.Constants.UserStatus.Active);
            if (existingUser != null)
                throw new Core.Exceptions.AuthException("email sudah terdaftar, gunakan email lain atau login");
            var salt = Commons.SecurityHelper.GenerateSalt(70);
            var hashedPassword = Commons.SecurityHelper.HashUsingSalt(request.Password, salt, 10101, salt.Length);
            var user = new Core.Databases.User
            {
                Email = request.Email,
                Salt = salt,
                HashedPassword = hashedPassword,
                Status = Core.Constants.UserStatus.Active,
                Name = request.Name,
                CreatedAt = Commons.DateTimeHelper.GetCurrentTime()
            };
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return new UserRegisterResponse
            {
                 UserUID = user.UID,
            };
        }
    }
}
