using Application.Contracts;
using Domain.Entities;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;


public sealed class StudentGroupService(DataContext dbContext) : IStudentGroupService
{
    public List<StudentGroup> GetStudentGroups(int id)
        => dbContext.StudentGroups.AsNoTracking().Where(s => s.StudentId == id).ToList();

    public List<Student> GetStudents(int id)
        =>dbContext.Students.AsNoTracking().Where(s => s.Id == id).ToList();

    public List<StudentGroup> GetStudentsByGroup(int groupId)
        => dbContext.StudentGroups.AsNoTracking().Where(s => s.GroupId == groupId).ToList();
    
    public List<Student> GetStudentsByMentor(int mentorId)
        =>dbContext.Students.AsNoTracking().Where(s => s.Id == mentorId).ToList();
        
    
}