namespace Domain.Entities;

public sealed class Group : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;

    public List<MentorGroup> MentorGroups { get; set; } = [];
    public List<StudentGroup> StudentGroups { get; set; } = [];
    
}