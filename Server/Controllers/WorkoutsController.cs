using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Shared;

//api controller setup
[ApiController]
[Route("api/[controller]")]
public class WorkoutsController : ControllerBase
{

    //initialise constructor
    private readonly AppDbContext _context;

    public WorkoutsController(AppDbContext context)
    {
        _context = context;
    }    

    //Async for endpoints
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var workouts = await _context.Workouts.ToListAsync();
        return Ok(workouts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var workout = await _context.Workouts.FindAsync(id);
        if (workout == null) return NotFound();
        return Ok(workout);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Workout workout)
    {
        //Stage the new workout
        _context.Workouts.Add(workout);
        //Save it to the DB
        await _context.SaveChangesAsync();
        //Return a 201 with a Location header
        return CreatedAtAction(nameof(GetById), new {id = workout.Id}, workout);
        
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> Update(int id, Workout workout)
    {
        //Ensure URL id matches the body to prevent mismatched updates
        if (id != workout.Id) return BadRequest();
        //Tell Entity Framework that the workout has been modified
        _context.Entry(workout).State = EntityState.Modified;
        //Save it to the DB
        await _context.SaveChangesAsync();
        //return a 204
        return NoContent();

    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete(int id)
    {
        //check ID exists
        var workout = await _context.Workouts.FindAsync(id);
        if (workout == null) return NotFound();
        //Delete the entry
        _context.Workouts.Remove(workout);
        //Save changes
        await _context.SaveChangesAsync();
        //return a 204
        return NoContent();
    }



}