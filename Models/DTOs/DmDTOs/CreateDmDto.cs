namespace Models.DTOs.DmDTOs;

public class CreateDmDto
{
    public Guid SenderID { get; set; }
    public Guid ReceiverID { get; set; }
    public required string Content { get; set; }
    public DateTime SentAt { get; set; }
    public required string Status { get; set; }
}
