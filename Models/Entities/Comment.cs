namespace Models.Entities;

public class Comment
{
    public Guid ID { get; set; }
    public Guid UserID { get; set; }
    public Guid PostID { get; set; }
    public DateTime SentAt { get; set; }
    public required string Content { get; set; }

    public virtual required User User { get; set; }
    public virtual required Post Post { get; set; }

    public virtual ICollection<CommentLike>? CommentLikes { get; set; }
}
