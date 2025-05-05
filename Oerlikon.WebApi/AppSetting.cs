using Oerlikon.Core.Interfaces;

namespace Oerlikon.WebApi
{
    public class AppSetting : IAppSetting
    {
        private readonly IConfiguration _configuration;
        public AppSetting(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public string JwtSecretKey
        {
            get
            {

                return _configuration.GetValue<string>("JwtSecretKey");
            }
        }
        public string JwtIssuer
        {
            get
            {

                return _configuration.GetValue<string>("JwtIssuer");
            }
        }
        public string JwtAudience
        {
            get
            {

                return _configuration.GetValue<string>("JwtIssuer");
            }
        }
    }
}
