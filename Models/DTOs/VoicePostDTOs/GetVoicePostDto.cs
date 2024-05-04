namespace Models.DTOs.VoicePostDTOs;

public class GetVoicePostDto
{
    public Guid ID { get; set; }
    public required string Url { get; set; }
    public required string Duration { get; set; }
    public required string Format { get; set; }
}
