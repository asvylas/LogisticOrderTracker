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
  public class ProductManagersController : ControllerBase
  {
    private readonly LogisticOrderTrackerContext _context;

    public ProductManagersController(LogisticOrderTrackerContext context)
    {
      _context = context;
    }

    // GET: api/ProductManagers
    [HttpGet]
    public IEnumerable<ProductManager> GetProductManager()
    {
      return _context.ProductManager;
    }

    // GET: api/ProductManagers/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductManager([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var productManager = await _context.ProductManager.FindAsync(id);

      if (productManager == null)
      {
        return NotFound();
      }

      return Ok(productManager);
    }

    // PUT: api/ProductManagers/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProductManager([FromRoute] int id, [FromBody] ProductManager productManager)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != productManager.Id)
      {
        return BadRequest();
      }

      _context.Entry(productManager).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ProductManagerExists(id))
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

    // POST: api/ProductManagers
    [HttpPost]
    public async Task<IActionResult> PostProductManager([FromBody] ProductManager productManager)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.ProductManager.Add(productManager);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetProductManager", new { id = productManager.Id }, productManager);
    }

    // DELETE: api/ProductManagers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductManager([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var productManager = await _context.ProductManager.FindAsync(id);
      if (productManager == null)
      {
        return NotFound();
      }

      _context.ProductManager.Remove(productManager);
      await _context.SaveChangesAsync();

      return Ok(productManager);
    }

    private bool ProductManagerExists(int id)
    {
      return _context.ProductManager.Any(e => e.Id == id);
    }
  }
}