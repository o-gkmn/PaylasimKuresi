using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities;

public class ImagePost
{
    public Guid ID { get; set; }
    public required string Url { get; set; }
    public required string Format { get; set; }
    public string? Caption { get; set; }
    public required string Size { get; set; }
}
