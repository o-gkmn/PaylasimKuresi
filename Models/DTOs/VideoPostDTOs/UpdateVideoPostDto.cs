namespace Models.DTOs.VideoPostDTOs;

public class UpdateVideoPostDto
{
    public Guid ID { get; set; }
    public required string Url { get; set; }
    public required string Thumbnail { get; set; }
    public required string Format { get; set; }
    public required string Duration { get; set; }
}
