using Models.Entities;

namespace Models.DTOs.GroupUserDTOs;

public class GetGroupUserDto
{
    public Guid ID { get; set; }
    public Guid UserID { get; set; }
    public Guid GroupID { get; set; }

    public required User Member { get; set; }
    public required Group Group { get; set; }
}
