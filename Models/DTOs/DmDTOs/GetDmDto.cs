using System.Text.Json.Serialization;
using Models.Entities;

namespace Models.DTOs.DmDTOs;

public class GetDmDto
{
    public Guid ID { get; set; }
    public Guid SenderID { get; set; }
    public Guid ReceiverID { get; set; }
    public required string Content { get; set; }
    public DateTime SentAt { get; set; }
    public required string Status { get; set; }

    [JsonIgnore]
    public User? Sender { get; set; }
    [JsonIgnore]
    public User? Receiver { get; set; }
}
