
namespace Models.DTOs.CommunityDTOs;

public class UpdateCommunityDto
{
    public Guid ID { get; set; }
    public Guid FounderID { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
}
