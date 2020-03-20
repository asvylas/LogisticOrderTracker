using LogisticOrderTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticOrderTracker.Controllers
{
  // [Authorize("Kaunas")]
  [Route("api/[controller]")]
  [ApiController]
  public class ForwardersController : ControllerBase
  {
    private readonly LogisticOrderTrackerContext _context;

    public ForwardersController(LogisticOrderTrackerContext context)
    {
      _context = context;
    }

    // GET: api/Forwarders
    [HttpGet]
    public async Task<IEnumerable<Forwarder>> GetForwarder()
    {
      var forwarders = await _context.Forwarder.Where(e => e.Active == true).ToListAsync();
      return forwarders;
    }

    // GET: api/Forwarders/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetForwarder([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var forwarder = await _context.Forwarder.FindAsync(id);

      if (forwarder == null)
      {
        return NotFound();
      }

      return Ok(forwarder);
    }

    // PUT: api/Forwarders/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutForwarder([FromRoute] int id, [FromBody] Forwarder forwarder)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != forwarder.Id)
      {
        return BadRequest();
      }

      _context.Entry(forwarder).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ForwarderExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Forwarders
    [HttpPost]
    public async Task<IActionResult> PostForwarder([FromBody] Forwarder forwarder)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.Forwarder.Add(forwarder);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetForwarder", new { id = forwarder.Id }, forwarder);
    }

    // DELETE: api/Forwarders/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteForwarder([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var forwarder = await _context.Forwarder.FindAsync(id);
      if (forwarder == null)
      {
        return NotFound();
      }

      _context.Forwarder.Remove(forwarder);
      await _context.SaveChangesAsync();

      return Ok(forwarder);
    }

    private bool ForwarderExists(int id)
    {
      return _context.Forwarder.Any(e => e.Id == id);
    }
  }
}