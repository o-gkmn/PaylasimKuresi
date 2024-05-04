namespace Models.DTOs.CommentLikeDTOs;

public class CreateCommentLikeDto
{
    public Guid CommentID { get; set; }
    public Guid UserID { get; set; }
    public DateTime LikedAt { get; set; }
}
