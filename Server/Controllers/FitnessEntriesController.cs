using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Shared;

//api controller setup
[ApiController]
[Route("api/[controller]")]
public class FitnessEntriesController : ControllerBase
{

    //initialise constructor
    private readonly AppDbContext _context;

    public FitnessEntriesController(AppDbContext context)
    {
        _context = context;
    }    

    //Async for endpoints
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var fitnessEntries = await _context.FitnessEntries.ToListAsync();
        return Ok(fitnessEntries);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var fitnessEntry = await _context.FitnessEntries.FindAsync(id);
        if (fitnessEntry == null) return NotFound();
        return Ok(fitnessEntry);
    }

    [HttpPost]
    public async Task<IActionResult> Create(FitnessEntry fitnessEntry)
    {
        //Stage the new fitness entry
        _context.FitnessEntries.Add(fitnessEntry);
        //Save it to the DB
        await _context.SaveChangesAsync();
        //Return a 201 with a Location header
        return CreatedAtAction(nameof(GetById), new {id = fitnessEntry.Id}, fitnessEntry);
        
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> Update(int id, FitnessEntry fitnessEntry)
    {
        //Ensure URL id matches the body to prevent mismatched updates
        if (id != fitnessEntry.Id) return BadRequest();
        //Tell Entity Framework that the fitness entry has been modified
        _context.Entry(fitnessEntry).State = EntityState.Modified;
        //Save it to the DB
        await _context.SaveChangesAsync();
        //return a 204
        return NoContent();

    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete(int id)
    {
        //check ID exists
        var fitnessEntry = await _context.FitnessEntries.FindAsync(id);
        if (fitnessEntry == null) return NotFound();
        //Delete the entry
        _context.FitnessEntries.Remove(fitnessEntry);
        //Save changes
        await _context.SaveChangesAsync();
        //return a 204
        return NoContent();
    }



}