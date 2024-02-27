
using System.ComponentModel.DataAnnotations;

namespace AuthenticationServiceApi.Models.Dtos.UserDtos
{
    public class SignUpUserDto
    {
        [Required(ErrorMessage = "Kullanıcı adı boş olamaz")]
        [MinLength(3, ErrorMessage = "Kullanıcı adı 3 karakterden az olamaz")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
