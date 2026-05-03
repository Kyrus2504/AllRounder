using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Shared;

//api controller setup
[ApiController]
[Route("api/[controller]")]
public class MealsController : ControllerBase
{

    //initialise constructor
    private readonly AppDbContext _context;

    public MealsController(AppDbContext context)
    {
        _context = context;
    }    

    //Async for endpoints
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var meals = await _context.Meals.ToListAsync();
        return Ok(meals);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var meal = await _context.Meals.FindAsync(id);
        if (meal == null) return NotFound();
        return Ok(meal);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Meal meal)
    {
        //Stage the new meal
        _context.Meals.Add(meal);
        //Save it to the DB
        await _context.SaveChangesAsync();
        //Return a 201 with a Location header
        return CreatedAtAction(nameof(GetById), new {id = meal.Id}, meal);
        
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> Update(int id, Meal meal)
    {
        //Ensure URL id matches the body to prevent mismatched updates
        if (id != meal.Id) return BadRequest();
        //Tell Entity Framework that the meal has been modified
        _context.Entry(meal).State = EntityState.Modified;
        //Save it to the DB
        await _context.SaveChangesAsync();
        //return a 204
        return NoContent();

    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete(int id)
    {
        //check ID exists
        var meal = await _context.Meals.FindAsync(id);
        if (meal == null) return NotFound();
        //Delete the entry
        _context.Meals.Remove(meal);
        //Save changes
        await _context.SaveChangesAsync();
        //return a 204
        return NoContent();
    }



}

