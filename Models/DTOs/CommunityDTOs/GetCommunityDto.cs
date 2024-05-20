using System.Text.Json.Serialization;
using Models.Entities;

namespace Models.DTOs.CommunityDTOs;

public class GetCommunityDto
{
    public Guid ID { get; set; }
    public Guid FounderID { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }

    [JsonIgnore]
    public User? Founder { get; set; }

    [JsonIgnore]
    public ICollection<CommunityUser>? CommunityUsers { get; set; }
}
