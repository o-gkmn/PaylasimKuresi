using Microsoft.AspNetCore.Identity;

namespace Models.Entities;

public class User : IdentityUser<Guid>
{
    public string FullName { get; set; }
    public string ProfilePicture { get; set; }
    public string Description { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
}
