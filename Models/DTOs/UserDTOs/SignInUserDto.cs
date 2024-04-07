using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.UserDTOs
{
    public class SignInUserDto
    {
        [Required(ErrorMessage = "Username cannot be empty!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password cannot be empty!")]
        public string Password { get; set; }
    }
}
