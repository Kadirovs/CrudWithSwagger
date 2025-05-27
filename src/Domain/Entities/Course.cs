namespace Domain.Entities;

public sealed class Course : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public List<Group> Groups { get; set; } = [];
}