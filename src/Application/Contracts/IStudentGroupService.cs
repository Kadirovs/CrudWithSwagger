using Domain.Entities;
namespace Application.Contracts;

public interface IStudentGroupService
{
    List<StudentGroup> GetStudentGroups(int id);
    List<Student> GetStudents(int id);
    List<StudentGroup> GetStudentsByGroup(int groupId);
    List<Student> GetStudentsByMentor(int mentorId);
    
}