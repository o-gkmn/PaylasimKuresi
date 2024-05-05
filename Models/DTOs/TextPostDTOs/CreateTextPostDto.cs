namespace Models.DTOs.TextPostDTOs;

public class CreateTextPostDto
{
    public required string Content { get; set; }
    public Guid CommunityId { get; set; }
    public Guid UserID { get; set; }
    public required string Status { get; set; }
}
