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
    => dbContext.Students.AsNoTracking().FirstOrDefault(x => x.Id == id);
    

    public bool CreateStudent(Student student)
    {
        Student? existingStudent = dbContext.Students.AsNoTracking()
            .FirstOrDefault(x => x.Email == student.Email);
        if (existingStudent != null)
            return false;
        dbContext.Students.Add(student);
        int res = dbContext.SaveChanges();
        if (res == 0)
            return false;
        return true;
    }

    public bool UpdateStudent(Student student)
    {
        Student? existingStudent = dbContext.Students.AsNoTracking()
            .FirstOrDefault(x => x.Id == student.Id);
        if (existingStudent == null)
            return false;
        
        dbContext.Students.Update(student);
        int res = dbContext.SaveChanges();
        if (res == 0)
            return false;
        return true;
    }

    public bool DeleteStudent(int id)
    {
        Student? existingStudent = dbContext.Students.AsNoTracking()
            .FirstOrDefault(x => x.Id == id);
        if (existingStudent == null)
            return false;
        
        dbContext.Students.Remove(existingStudent);
        int res = dbContext.SaveChanges();
        if (res == 0)
            return false;
        return true;
    }
}