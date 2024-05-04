namespace Models.DTOs.DmDTOs;

public class UpdateDmDto
{
    public Guid ID { get; set; }
    public Guid SenderID { get; set; }
    public Guid ReceiverID { get; set; }
    public required string Content { get; set; }
    public DateTime SentAt { get; set; }
    public required string Status { get; set; }
}
