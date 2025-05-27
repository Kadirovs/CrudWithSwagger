using Application.Contracts;
using Domain.Entities;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;

public sealed class CourseService(DataContext dbContext) : ICourseService
{
    public List<Course> GetCourses()
        => dbContext.Courses.AsNoTracking().ToList();


    public Course? GetCourseById(int id)
        => dbContext.Courses.AsNoTracking().FirstOrDefault(x => x.Id == id);

    public bool CreateCourse(Course course)
    {
        Course? existingCourse = dbContext.Courses.AsNoTracking().FirstOrDefault(x => x.Name == course.Name);
        if (existingCourse != null)
            return false;

        dbContext.Courses.Add(course);
        int res = dbContext.SaveChanges();
        if (res == 0)
            return false;

        return true;
    }

    public bool UpdateCourse(Course course)
    {
        Course? existingCourse = dbContext.Courses.AsNoTracking().FirstOrDefault(x => x.Id == course.Id);
        if (existingCourse == null)
            return false;
        
        dbContext.Courses.Update(course);
        int res = dbContext.SaveChanges();
        if (res == 0)
            return false;

        return true;
    }

    public bool DeleteCourse(int id)
    {
        Course? existingCourse = dbContext.Courses.AsNoTracking().FirstOrDefault(x => x.Id == id);
        if (existingCourse == null)
            return false;

        dbContext.Courses.Remove(existingCourse);
        int res = dbContext.SaveChanges();
        if (res == 0)
            return false;
        
        return true;
    }
}