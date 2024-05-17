using System.Text.Json.Serialization;
using Models.Entities;

namespace Models.DTOs.UserDTOs;

public class GetUserDto
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string? Description { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public required string Email { get; set; }
    public required string UserName { get; set; }

    [JsonIgnore]
    public ICollection<Comment>? Comments { get; set; }

    [JsonIgnore]
    public ICollection<CommentLike>? CommentLikes { get; set; }

    [JsonIgnore]
    public ICollection<Community>? FounderOfCommunity { get; set; }

    [JsonIgnore]
    public ICollection<CommunityUser>? MemberCommunities { get; set; }

    [JsonIgnore]
    public ICollection<Dm>? Senders { get; set; }

    [JsonIgnore]
    public ICollection<Dm>? Receivers { get; set; }

    [JsonIgnore]
    public ICollection<Follow>? Followers { get; set; }

    [JsonIgnore]
    public ICollection<Follow>? Following { get; set; }

    [JsonIgnore]
    public ICollection<Group>? FounderOfGroups { get; set; }

    [JsonIgnore]
    public ICollection<GroupUser>? MemberGroups { get; set; }

    [JsonIgnore]
    public ICollection<PostLike>? LikedPosts { get; set; }
}
