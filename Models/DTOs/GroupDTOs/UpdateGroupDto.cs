namespace Models.DTOs.GroupDTOs;

public class UpdateGroupDto
{
    public Guid ID { get; set; }
    public Guid FounderID { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
}
