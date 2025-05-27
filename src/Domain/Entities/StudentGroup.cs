namespace Domain.Entities;

public sealed class StudentGroup : BaseEntity
{
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;

    public int GroupId { get; set; }
    public Group Group { get; set; } = null!;
    
    public List<StudentGroup> StudentGroups { get; set; } = [];
}