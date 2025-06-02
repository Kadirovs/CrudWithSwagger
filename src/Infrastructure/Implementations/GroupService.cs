using Application.Contracts;
using Domain.Entities;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;

public sealed class GroupService(DataContext dbContext) : IGroupService
{
    public List<Group> GetGroups()
        => dbContext.Groups.AsNoTracking().ToList();
    

    public Group? GetGroupById(int id)
        => dbContext.Groups.AsNoTracking().FirstOrDefault(x => x.Id == id);

    public bool CreateGroup(Group group)
    {
        Group? existingGroup = dbContext.Groups.AsNoTracking()
            .FirstOrDefault(x => x.Name == group.Name);
        if (existingGroup != null)
            return false;
        dbContext.Groups.Add(group);
        int res = dbContext.SaveChanges();
        if (res == 0)
            return false;
        return true;
    }

    public bool UpdateGroup(Group group)
    {
        Group? existingGroup = dbContext.Groups.AsNoTracking()
            .FirstOrDefault(x => x.Id == group.Id);
        if (existingGroup == null)
            return false;
        
        dbContext.Groups.Update(group);
        int res = dbContext.SaveChanges();
        if (res == 0)
            return false;
        return true;
    }

    public bool DeleteGroup(int id)
    {
        Group? existingGroup = dbContext.Groups.AsNoTracking()
            .FirstOrDefault(x => x.Id == id);
        if (existingGroup == null)
            return false;
        
        dbContext.Groups.Remove(existingGroup);
        int res = dbContext.SaveChanges();
        if (res == 0)
            return false;
        return true;
    }
}