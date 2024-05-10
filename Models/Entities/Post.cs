namespace Models.Entities;

public class Post
{
    public Guid ID { get; set; }
    public Guid UserID { get; set; }

    public Guid? TextPostID { get; set; }
    public Guid? ImagePostID { get; set; }
    public Guid? VideoPostID { get; set; }
    public Guid? VoicePostID { get; set; }

    public TextPost? TextPost { get; set; }
    public ImagePost? ImagePost { get; set; }
    public VideoPost? VideoPost { get; set; }
    public VoicePost? VoicePost { get; set; }

    public Guid CommunityID { get; set; }
    public required string Status { get; set; }
    public DateTime CreatedAt { get; set; }

    public required User User { get; set; }
    //public required Community Community { get; set; }

    public ICollection<Comment>? Comments { get; set; }
    public required ICollection<PostLike> UsersWhoLike { get; set; }
}
