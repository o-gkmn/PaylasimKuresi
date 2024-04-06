using Microsoft.AspNetCore.Identity;

namespace Models.Entities;

public class UserEntity : IdentityUser<Guid>
{
    public string FullName;
    public string ProfilePicture;
    public string Description;
    public DateTime DateOfBirth;
    public string Gender;
}