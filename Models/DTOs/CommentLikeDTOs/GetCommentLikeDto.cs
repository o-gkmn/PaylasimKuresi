using Models.Entities;

namespace Models.DTOs.CommentLikeDTOs;

public class GetCommentLikeDto
{
    public Guid ID { get; set; }
    public Guid CommentID { get; set; }
    public Guid UserID { get; set; }
    public DateTime LikedAt { get; set; }

    public required Comment Comment { get; set; }
    public required User User { get; set; }
}
