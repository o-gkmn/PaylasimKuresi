
using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.UserDTOs
{
    public class SignUpUserDto
    {
        [Required(ErrorMessage = "Username cannot be empty!")]
        [MinLength(3, ErrorMessage = "Username length must be at least 3 characters!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password cannot be empty!")]
        [MinLength(8, ErrorMessage = "Password length must be at least 8 characters!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email cannot be empty")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You have entered the wrong email")]
        public string Email { get; set; }
        public string FullName { get; set; }
        public string ProfilePicture { get; set; }
        public string Description { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
    }
}
