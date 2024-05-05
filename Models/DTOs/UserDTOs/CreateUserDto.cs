using System.ComponentModel.DataAnnotations;
using Models.Attributes;

namespace Models.DTOs.UserDTOs;

public class CreateUserDto
{
    [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz.")]
    [MinLength(3, ErrorMessage = "Kullanıcı adı en az 3 karakter uzunluğunda olmalıdır.")]
    public required string UserName { get; set; }

    [Required(ErrorMessage = "Şifre boş bırakılamaz.")]
    [MinLength(8, ErrorMessage = "Şifre en az 8 karakter uzunluğunda olmalıdır.")]
    public required string Password { get; set; }

    [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
    public required string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "Eposta boş bırakılamaz.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Geçersiz eposta adresi girdiniz.")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "İsim giriniz.")]
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "Soyad giriniz.")]
    public required string LastName { get; set; }

    [Required(ErrorMessage = "Doğum tarihini giriniz.")]
    [MinimumAge(13, ErrorMessage = "13 Yaşından büyük olmalısınız.")]
    public required string DateOfBirth { get; set; }

    [Required(ErrorMessage = "Cinsiyet seçiniz.")]
    public required string Gender { get; set; }
    public string? PhoneNumber { get; set; }
}
