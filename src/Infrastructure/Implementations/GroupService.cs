using Application.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;

public sealed class GroupService(DbContext dbContext):IGroupService
{
    public List<Group> GetGroups()
    {
        throw new NotImplementedException();
    }

    public Group? GetGroupById(int id)
    {
        throw new NotImplementedException();
    }

    public bool CreateGroup(Group group)
    {
        throw new NotImplementedException();
    }

    public bool UpdateGroup(Group group)
    {
        throw new NotImplementedException();
    }

    public bool DeleteGroup(int id)
    {
        throw new NotImplementedException();
    }
}