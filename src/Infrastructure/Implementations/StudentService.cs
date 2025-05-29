using Application.Contracts;
using Domain.Entities;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Implementations;

public sealed class StudentService(DataContext dbContext) : IStudentService
{
    public List<Student> GetStudents() 
        => dbContext.Students.AsNoTracking().ToList();

    public Student? GetStudentById(int id)
    {
        throw new NotImplementedException();
    }

    public bool CreateStudent(Student student)
    {
        throw new NotImplementedException();
    }

    public bool UpdateStudent(Student student)
    {
        throw new NotImplementedException();
    }

    public bool DeleteStudent(int id)
    {
        throw new NotImplementedException();
    }
}