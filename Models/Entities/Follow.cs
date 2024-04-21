namespace Models.Entities;

public class Follow
{
    public Guid ID { get; set; }
    public Guid FollowingPersonID { get; set; }
    public Guid FollowedPersonID { get; set; }
    public DateTime FollowedAt { get; set; }

    public required User FollowingPerson { get; set; }
    public required User FollowedPerson { get; set; }
}
