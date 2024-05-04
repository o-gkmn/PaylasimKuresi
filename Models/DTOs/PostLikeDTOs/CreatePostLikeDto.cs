namespace Models.DTOs.PostLikeDTOs;

public class CreatePostLikeDto
{
    public Guid UserID { get; set; }
    public Guid PostID { get; set; }
    public DateTime LikedAt { get; set; }
}
