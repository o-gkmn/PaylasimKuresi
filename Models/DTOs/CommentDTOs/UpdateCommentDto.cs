namespace Models.DTOs.CommentDTOs;

public class UpdateCommentDto
{
    public Guid ID { get; set; }
    public Guid UserID { get; set; }
    public Guid PostID { get; set; }
    public DateTime SentAt { get; set; }
    public required string Content { get; set; }
}
