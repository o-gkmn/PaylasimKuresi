namespace Models.DTOs.GroupUserDTOs;

public class UpdateGroupUserDto
{
    public Guid ID { get; set; }
    public Guid UserID { get; set; }
    public Guid GroupID { get; set; }
}
