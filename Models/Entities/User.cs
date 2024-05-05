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

    public ICollection<Comment>? Comments { get; set; }
    public ICollection<CommentLike>? CommentLikes { get; set; }
    public ICollection<Community>? FounderOfCommunity { get; set; }
    public required ICollection<CommunityUser> MemberCommunities { get; set; }
    public required ICollection<Dm> Senders { get; set; }
    public required ICollection<Dm> Receivers { get; set; }
    public required ICollection<Follow> Followers { get; set; }
    public required ICollection<Follow> Following { get; set; }
    public required ICollection<Group> FounderOfGroups { get; set; }
    public required ICollection<GroupUser> MemberGroups { get; set; }
    public required ICollection<PostLike> LikedPosts { get; set; }
}
