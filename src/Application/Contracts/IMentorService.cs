using Domain.Entities;

namespace Application.Contracts;

public interface IMentorService
{
    List<Mentor> GetMentors();
    List<Mentor> GetMentorsByCourseId(int courseId);
    Mentor? GetMentorById(int id);
    bool CreateMentor(Mentor mentor);
    bool UpdateMentor(Mentor mentor);
    bool DeleteMentor(int id);
}