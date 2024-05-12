namespace Models.Entities;

public class Community
{
    public Guid ID { get; set; }
    public Guid FounderID { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual required User Founder { get; set; }
    public virtual required ICollection<CommunityUser> CommunityUsers { get; set; }
}
