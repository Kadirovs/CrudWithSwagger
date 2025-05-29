using Domain.Entities;

namespace Application.Contracts;

public interface IStudentService
{
    List<Student> GetStudents();
    Student? GetStudentById(int id);
    bool CreateStudent(Student student);
    bool UpdateStudent(Student student);
    bool DeleteStudent(int id);
}