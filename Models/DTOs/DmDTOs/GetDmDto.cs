using System.Text.Json.Serialization;
using Models.Entities;

namespace Models.DTOs.DmDTOs;

public class GetDmDto
{
    [JsonPropertyName("id")]
    public Guid ID { get; set; }

    [JsonPropertyName("senderId")]
    public Guid SenderID { get; set; }

    [JsonPropertyName("receiverId")]
    public Guid ReceiverID { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("sentAt")]
    public DateTime SentAt { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonIgnore]
    public User? Sender { get; set; }
    [JsonIgnore]
    public User? Receiver { get; set; }
}
