namespace Models.DTOs.CommentLikeDTOs;

public class UpdateCommentLikeDto
{
    public Guid ID { get; set; }
    public Guid CommentID { get; set; }
    public Guid UserID { get; set; }
    public DateTime LikedAt { get; set; }
}
