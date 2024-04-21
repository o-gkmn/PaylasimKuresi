using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities;

public class TextPost
{
    public Guid ID { get; set; }
    public required string Content { get; set; }

    public Guid PostID { get; set; }

    [ForeignKey("PostID")]
    public required Post Post { get; set; }
}
