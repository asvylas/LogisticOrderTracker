using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LogisticOrderTracker.Models;

namespace LogisticOrderTracker.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AddressContactsController : ControllerBase
  {
    private readonly LogisticOrderTrackerContext _context;

    public AddressContactsController(LogisticOrderTrackerContext context)
    {
      _context = context;
    }

    // GET: api/AddressContacts
    [HttpGet]
    public IEnumerable<AddressContact> GetAddressContact()
    {
      return _context.AddressContact;
    }

    // GET: api/AddressContacts/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAddressContact([FromRoute] int id)
    {
      var addressContact = await _context.AddressContact.Where(e => e.AddressId == id).ToListAsync();

      if (addressContact == null)
      {
        return NotFound();
      }

      return Ok(addressContact);
    }

    // PUT: api/AddressContacts/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAddressContact([FromRoute] int id, [FromBody] AddressContact addressContact)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != addressContact.Id)
      {
        return BadRequest();
      }

      _context.Entry(addressContact).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AddressContactExists(id))
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

    // POST: api/AddressContacts
    [HttpPost]
    public async Task<IActionResult> PostAddressContact([FromBody] AddressContact addressContact)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.AddressContact.Add(addressContact);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetAddressContact", new { id = addressContact.Id }, addressContact);
    }

    // DELETE: api/AddressContacts/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAddressContact([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var addressContact = await _context.AddressContact.FindAsync(id);
      if (addressContact == null)
      {
        return NotFound();
      }

      _context.AddressContact.Remove(addressContact);
      await _context.SaveChangesAsync();

      return Ok(addressContact);
    }

    private bool AddressContactExists(int id)
    {
      return _context.AddressContact.Any(e => e.Id == id);
    }
  }
}