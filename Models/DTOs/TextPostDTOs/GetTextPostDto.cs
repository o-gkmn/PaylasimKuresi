namespace Models.DTOs.TextPostDTOs;

public class GetTextPostDto
{
    public Guid Id { get; set; }
    public required string Content { get; set; }
}
