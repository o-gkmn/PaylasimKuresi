using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.UserDTOs
{
    public class SignInUserDto
    {
        [Required(ErrorMessage = "Eposta boş bırakılamaz.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Geçersiz eposta adresi girdiniz.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş bırakılamaz")]
        public required string Password { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
