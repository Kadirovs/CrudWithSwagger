using Domain.Entities;
namespace Application.Contracts;

public interface IGroupService
{
    List<Group> GetGroups();
    Group? GetGroupById(int id);
    bool CreateGroup(Group group);
    bool UpdateGroup(Group group);
    bool DeleteGroup(int id);
    
}