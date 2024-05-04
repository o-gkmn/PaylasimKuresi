namespace Models.DTOs.FollowDTOs;

public class CreateFollowDto
{
    public Guid FollowingPersonID { get; set; }
    public Guid FollowedPersonID { get; set; }
    public DateTime FollowedAt { get; set; }
}
