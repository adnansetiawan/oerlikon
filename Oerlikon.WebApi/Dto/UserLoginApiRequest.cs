using System.ComponentModel.DataAnnotations;

namespace Oerlikon.WebApi.Dto
{
    public class UserLoginApiRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
