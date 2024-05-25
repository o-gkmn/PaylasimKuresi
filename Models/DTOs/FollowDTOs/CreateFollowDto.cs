using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.FollowDTOs;

public class CreateFollowDto
{
    [Required]
    public Guid FollowingPersonID { get; set; }

    [Required]
    public Guid FollowedPersonID { get; set; }

    [Required]
    public DateTime FollowedAt { get; set; }
}
