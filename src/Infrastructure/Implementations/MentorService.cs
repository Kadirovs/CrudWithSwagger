using Application.Contracts;
using Domain.Entities;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;

public class MentorService(DataContext dbContext) : IMentorService
{
    public List<Mentor> GetMentors()
        => dbContext.Mentors.AsNoTracking().ToList();

    public List<Mentor> GetMentorsByCourseId(int courseId)
        => dbContext.Mentors.AsNoTracking().ToList();

    public Mentor? GetMentorById(int id)
        => dbContext.Mentors.AsNoTracking()
            .FirstOrDefault(x => x.Id == id);

    public bool CreateMentor(Mentor mentor)
    {
        Mentor? existingMentor = dbContext.Mentors.AsNoTracking()
            .FirstOrDefault(x => x.Id == mentor.Id);
        if (existingMentor != null)
            return false;
        dbContext.Mentors.Add(mentor);
        int res = dbContext.SaveChanges();
        if (res == 0)
            return false;
        return true;
    }

    public bool UpdateMentor(Mentor mentor)
    {
        Mentor? existingMentor = dbContext.Mentors.AsNoTracking()
            .FirstOrDefault(x => x.Id == mentor.Id);
        if (existingMentor == null)
            return false;
        
        dbContext.Mentors.Update(mentor);
        int res = dbContext.SaveChanges();
        if (res == 0)
            return false;
        return true;
    }

    public bool DeleteMentor(int id)
    {
        Mentor? existingMentor = dbContext.Mentors.AsNoTracking()
            .FirstOrDefault(x => x.Id == id);
        if (existingMentor == null)
            return false;
        
        dbContext.Mentors.Remove(existingMentor);
        int res = dbContext.SaveChanges();
        if (res == 0)
            return false;
        return true;
    }
}