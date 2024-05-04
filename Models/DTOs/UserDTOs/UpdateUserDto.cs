namespace Models.DTOs.UserDTOs;

public class UpdateUserDto
{
    public Guid Id { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public string? FullName { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string? Description { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Gender { get; set; }
}
