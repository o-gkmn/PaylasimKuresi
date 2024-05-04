namespace Models.DTOs.PostLikeDTOs;

public class UpdatePostLikeDto
{
    public Guid ID { get; set; }
    public Guid UserID { get; set; }
    public Guid PostID { get; set; }
    public DateTime LikedAt { get; set; }
}
