using Microsoft.AspNetCore.Identity;

namespace Models.Entities;

public class User : IdentityUser<Guid>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string? Description { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Gender { get; set; }

    public virtual ICollection<Post>? Posts { get; set; }
    public virtual ICollection<Comment>? Comments { get; set; }
    public virtual ICollection<CommentLike>? CommentLikes { get; set; }
    public virtual ICollection<Community>? FounderOfCommunity { get; set; }
    public virtual required ICollection<CommunityUser> MemberCommunities { get; set; }
    public virtual required ICollection<Dm> Senders { get; set; }
    public virtual required ICollection<Dm> Receivers { get; set; }
    public virtual required ICollection<Follow> Followers { get; set; }
    public virtual required ICollection<Follow> Following { get; set; }
    public virtual required ICollection<Group> FounderOfGroups { get; set; }
    public virtual required ICollection<GroupUser> MemberGroups { get; set; }
    public virtual required ICollection<PostLike> LikedPosts { get; set; }
}
