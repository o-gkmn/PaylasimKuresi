
using System.ComponentModel.DataAnnotations;

namespace AuthenticationServiceApi.Models.Dtos.UserDtos
{
    public class SignUpUserDto
    {
        [Required(ErrorMessage = "Kullanıcı adı boş olamaz.")]
        [MinLength(3, ErrorMessage = "Kullanıcı adı 3 karakterden az olamaz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Parola boş bırakılamaz")]
        [MinLength(8, ErrorMessage = "Parola en az 8 karakterli olmalıdır.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "EPosta boş bırakılamaz.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Hatalı posta adresi girdiniz.")]
        public string Email { get; set; }
    }
}
