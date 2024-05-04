using Models.Entities;

namespace Models.DTOs.PostLikeDTOs;

public class GetPostLikeDto
{
    public Guid ID { get; set; }
    public Guid UserID { get; set; }
    public Guid PostID { get; set; }
    public DateTime LikedAt { get; set; }

    public required User User { get; set; }
    public required Post Post { get; set; }
}
