using Application.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[Route("api/mentors")]
[ApiController]
public sealed class MentorController(IMentorService mentorService):ControllerBase
{
    [HttpGet]
     public IActionResult Get()
     {
         return Ok(mentorService.GetMentors());
     }

    [HttpGet("{id:int}")]
    
    public IActionResult Get(int id)
    {
        Mentor? mentor = mentorService.GetMentorById(id);
        if (mentor is null)
            return NotFound();
        return Ok(mentor);
    }
    
    [HttpPost]
    public IActionResult Create([FromBody] Mentor mentor)
    {
        bool res = mentorService.CreateMentor(mentor);
        if (res == false)
            return BadRequest("Mentor already exist");
        return Ok(res);
    }
    
    [HttpPut]
    public IActionResult Update([FromBody] Mentor mentor)
    {
        bool res = mentorService.UpdateMentor(mentor);
        if (res == false)
            return NotFound("Mentor not found.");
        return Ok(res);
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        bool res = mentorService.DeleteMentor(id);
        if (res == false)
            return BadRequest("Mentor not found.");
        return Ok(res);
    }
    
}