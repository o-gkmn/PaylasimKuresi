namespace Models.Entities;

public class Dm
{
    public Guid ID { get; set; }
    public Guid SenderID { get; set; }
    public Guid ReceiverID { get; set; }
    public required string Content { get; set; }
    public DateTime SentAt { get; set; }
    public required string Status { get; set; }

    public required User Sender { get; set; }
    public required User Receiver { get; set; }
}
