namespace Models.DTOs.FollowDTOs;

public class UpdateFollowDto
{
    public Guid ID { get; set; }
    public Guid FollowingPersonID { get; set; }
    public Guid FollowedPersonID { get; set; }
    public DateTime FollowedAt { get; set; }
}
