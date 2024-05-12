namespace Models.Entities;

public class GroupUser
{
    public Guid ID { get; set; }
    public Guid UserID { get; set; }
    public Guid GroupID { get; set; }

    public virtual required User Member { get; set; }
    public virtual required Group Group { get; set; }
}
