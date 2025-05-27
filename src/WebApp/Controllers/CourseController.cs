using Application.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("api/courses")]
[ApiController]
public sealed class CourseController(ICourseService courseService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(courseService.GetCourses());
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        Course? course = courseService.GetCourseById(id);
        if (course is null)
            return NotFound();
        return Ok(course);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Course course)
    {
        bool res = courseService.CreateCourse(course);
        if (res == false)
            return BadRequest("Course already exist");
        return Ok(res);
    }


    [HttpPut]
    public IActionResult Update([FromBody] Course course)
    {
        bool res = courseService.UpdateCourse(course);
        if (res == false)
            return NotFound("Course not found.");
        return Ok(res);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        bool res = courseService.DeleteCourse(id);
        if (res == false)
            return BadRequest("Course not found.");
        return Ok(res);
    }
}   