namespace Models.Entities;

public class CommunityUser
{
    public Guid ID { get; set; }
    public Guid CommunityID { get; set; }
    public Guid UserID { get; set; }
    public Guid RoleID { get; set; }
    public DateTime JoinedAt { get; set; }

    public required Community Community { get; set; }
    public required User Member { get; set; }
}
