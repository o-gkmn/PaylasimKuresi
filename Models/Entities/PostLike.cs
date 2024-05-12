namespace Models.Entities;

public class PostLike
{
    public Guid ID { get; set; }
    public Guid UserID { get; set; }
    public Guid PostID { get; set; }
    public DateTime LikedAt { get; set; }

    public virtual required User User { get; set; }
    public virtual required Post Post { get; set; }
}
