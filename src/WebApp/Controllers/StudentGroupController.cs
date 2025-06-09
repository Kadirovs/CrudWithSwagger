using Application.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("api/[studentgroup]")]
[ApiController]
public sealed class StudentGroupController(IStudentGroupService studentGroupService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public IActionResult Get(int groupId)
    {
        List<StudentGroup> studentGroup = studentGroupService.GetStudentGroups(groupId);
        return Ok(studentGroup);
    }

    [HttpGet("{id:int}/students")]
    public IActionResult GetStudents(int id)
    {
        List<Student> students = studentGroupService.GetStudents(id);
        return Ok(students);
    }

    [HttpGet("{id:int}/students/{studentId:int}")]
    public IActionResult Get(int groupId, int studentId)
    {
        List<StudentGroup> studentGroup = studentGroupService.GetStudentGroups(groupId);
        return Ok(studentGroup);
    }

    [HttpGet("{id:int}/students/{studentId:int}/mentors")]
    public IActionResult GetStudents(int groupId, int id)
    {
        List<Student> students = studentGroupService.GetStudents(groupId);
        return Ok(students);
    }
}