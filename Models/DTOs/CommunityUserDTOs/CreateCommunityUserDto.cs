namespace Models.DTOs.CommunityUserDTOs;

public class CreateCommunityUserDto
{
    public Guid CommunityID { get; set; }
    public Guid UserID { get; set; }
    public Guid RoleID { get; set; }
    public DateTime JoinedAt { get; set; }
}
