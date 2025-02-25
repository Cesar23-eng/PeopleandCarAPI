using Microsoft.AspNetCore.Mvc;
using PeopleAPI.Data;
using PeopleAPI.Models;

namespace PeopleAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarController(ICarRepository carRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var people = await carRepository.GetAllAsync();
        return Ok(people);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var car = await carRepository.GetByIdAsync(id);
        if (car == null)
        {
            return NotFound();
        }
        return Ok(car);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Car car)
    {
        if (id != car.Id)
        {
            return BadRequest();
        }
        await carRepository.UpdateAsync(car);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Post(Car car)
    {
        await carRepository.AddAsync(car);
        return CreatedAtAction(nameof(GetAll), new { id = car.Id }, car);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await carRepository.DeleteAsync(id);
        return NoContent();
    }
}



