using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities;

public class VoicePost
{
    public Guid ID { get; set; }
    public required string Url { get; set; }
    public required string Duration { get; set; }
    public required string Format { get; set; }

    public Guid PostID { get; set; }

    [ForeignKey("PostID")]
    public required Post Post { get; set; }
}
