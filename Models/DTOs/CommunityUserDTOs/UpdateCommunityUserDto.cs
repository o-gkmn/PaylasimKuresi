namespace Models.DTOs.CommunityUserDTOs;

public class UpdateCommunityUserDto
{
    public Guid ID { get; set; }
    public Guid CommunityID { get; set; }
    public Guid UserID { get; set; }
    public Guid RoleID { get; set; }
    public DateTime JoinedAt { get; set; }
}
