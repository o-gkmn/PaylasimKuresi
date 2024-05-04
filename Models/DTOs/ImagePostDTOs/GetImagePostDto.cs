namespace Models.DTOs.ImagePostDTOs;

public class GetImagePostDto
{
    public Guid ID { get; set; }
    public required string Url { get; set; }
    public required string Format { get; set; }
    public string? Caption { get; set; }
    public required string Size { get; set; }
}
