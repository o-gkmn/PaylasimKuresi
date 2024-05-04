namespace Models.DTOs.VideoPostDTOs;

public class CreateVideoPostDto
{
    public required string Url { get; set; }
    public required string Thumbnail { get; set; }
    public required string Format { get; set; }
    public required string Duration { get; set; }
}
