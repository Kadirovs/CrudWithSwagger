namespace Domain.Entities;

public sealed class MentorGroup : BaseEntity
{
    public int MentorId { get; set; }
    public Mentor Mentor { get; set; } = null!;

    public int GroupId { get; set; }
    public Group Group { get; set; } = null!;
    
}