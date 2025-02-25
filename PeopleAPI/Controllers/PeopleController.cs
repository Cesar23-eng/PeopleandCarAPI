using Microsoft.AspNetCore.Mvc;
using PeopleAPI.Data;
using PeopleAPI.Models;

namespace PeopleAPI.Controllers;

//Tenemos el CRUD completo
[Route("api/[controller]")]
[ApiController]

public class PeopleController(IPersonRepository personRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var people = await personRepository.GetAllAsync();
        return Ok(people);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var person = await personRepository.GetByIdAsync(id);
        if (person == null)
        {
            return NotFound();
        }
        return Ok(person);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Person person)
    {
        if (id != person.Id)
        {
            return BadRequest();
        }
        
        await personRepository.UpdateAsync(person);
        return NoContent();
    }
    
//Post sirve para mandar datos y entran objetos
    [HttpPost]
    public async Task<IActionResult> Post(Person person)
    {
        await personRepository.AddAsync(person);
        return CreatedAtAction(nameof(GetAll), new { id = person.Id }, person);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await personRepository.DeleteAsync(id);
        return NoContent();
    }
}

