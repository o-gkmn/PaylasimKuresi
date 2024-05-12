namespace Models.Entities;

public class CommentLike
{
    public Guid ID { get; set; }
    public Guid CommentID { get; set; }
    public Guid UserID { get; set; }
    public DateTime LikedAt { get; set; }

    public virtual required Comment Comment { get; set; }
    public virtual required User User { get; set; }
}
