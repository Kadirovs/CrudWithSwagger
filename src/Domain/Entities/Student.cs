using Domain.Enums;

namespace Domain.Entities;

public sealed class Student : BaseEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public Gender Gender { get; set; }
    
}