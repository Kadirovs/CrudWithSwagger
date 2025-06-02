using Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;

namespace WebApp.Controllers;
[Route("api/groups")]
[ApiController]

public sealed class GroupController(IGroupService groupService):ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(groupService.GetGroups());
    }

    [HttpGet("{id:int}")]

    public IActionResult Get(int id)
    {
        Group? group = groupService.GetGroupById(id);
        if (group is null)
            return NotFound();
        return Ok(group);
        
    }
    
    [HttpPost]
    public IActionResult Create([FromBody] Group group)
    {
        bool res = groupService.CreateGroup(group);
        if (res == false)
            return BadRequest("Group already exist");
        return Ok(res);
    }
    
    [HttpPut]
    public IActionResult Update([FromBody] Group group)
    {
        bool res = groupService.UpdateGroup(group);
        if (res == false)
            return NotFound("Group not found.");
        return Ok(res);
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        bool res = groupService.DeleteGroup(id);
        if (res == false)
            return BadRequest("Group not found.");
        return Ok(res);
    }
}