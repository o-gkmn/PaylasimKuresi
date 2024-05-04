namespace Models.Entities;

public class Comment
{
    public Guid ID { get; set; }
    public Guid UserID { get; set; }
    public Guid PostID { get; set; }
    public DateTime SentAt { get; set; }
    public required string Content { get; set; }

    public required User User { get; set; }
    public required Post Post { get; set; }

    public ICollection<CommentLike>? CommentLikes { get; set; }
}
