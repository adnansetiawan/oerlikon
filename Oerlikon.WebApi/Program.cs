using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Oerlikon.Core.Interfaces;
using Oerlikon.WebApi;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Oerlikon.Core.Databases.DatabaseContext>
    (options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<IAppSetting, AppSetting>();
builder.Services.AddScoped<Oerlikon.Core.Interfaces.IUserRegisterService, Oerlikon.Core.Services.UserRegisterService>();
builder.Services.AddScoped<Oerlikon.Core.Interfaces.IAuthService, Oerlikon.Core.Services.AuthService>();
var appSetting = new AppSetting(builder.Configuration);
var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(appSetting.JwtSecretKey));
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(hmac.Key),
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidIssuer = appSetting.JwtIssuer,
            ValidAudience = appSetting.JwtAudience,
            ClockSkew = TimeSpan.Zero
        };
    });
builder.Services.AddAuthorization();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
