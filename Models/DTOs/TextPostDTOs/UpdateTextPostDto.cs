namespace Models.DTOs.TextPostDTOs;

public class UpdateTextPostDto
{
    public Guid Id { get; set; }
    public required string Content { get; set; }
}
