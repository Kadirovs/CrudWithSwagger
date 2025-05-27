using Domain.Entities;

namespace Application.Contracts;

public interface ICourseService
{
    List<Course> GetCourses();
    Course? GetCourseById(int id);
    bool CreateCourse(Course course);
    bool UpdateCourse(Course course);
    bool DeleteCourse(int id);
}