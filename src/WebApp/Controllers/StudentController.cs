using Application.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("api/students")]
[ApiController]
public sealed class StudentController(IStudentService studentService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(studentService.GetStudents());
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        Student? student = studentService.GetStudentById(id);
        if (student is null)
            return NotFound();
        return Ok(student);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Student student)
    {
        bool res = studentService.CreateStudent(student);
        if (res == false)
            return BadRequest("Student already exist");
        return Ok(res);
    }


    [HttpPut]
    public IActionResult Update([FromBody] Student student)
    {
        bool res = studentService.UpdateStudent(student);
        if (res == false)
            return NotFound("Student not found.");
        return Ok(res);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        bool res = studentService.DeleteStudent(id);
        if (res == false)
            return BadRequest("Student not found.");
        return Ok(res);
    }
}