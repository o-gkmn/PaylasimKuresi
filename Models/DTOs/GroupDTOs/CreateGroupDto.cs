namespace Models.DTOs.GroupDTOs;

public class CreateGroupDto
{
    public Guid FounderID { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
}
