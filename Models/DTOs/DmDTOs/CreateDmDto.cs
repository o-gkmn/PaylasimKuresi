using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.DmDTOs;

public class CreateDmDto
{
    public Guid SenderID { get; set; }
    public Guid ReceiverID { get; set; }

    [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz.")]
    public required string ReceiverUserName { get; set; }

    [Required(ErrorMessage = "Boş mesaj gönderilemez.")]
    public required string Content { get; set; }
    public DateTime SentAt { get; set; }
    public required string Status { get; set; }
}
