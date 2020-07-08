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
    public class PackagesController : ControllerBase
    {
        private readonly LogisticOrderTrackerContext _context;

        public PackagesController(LogisticOrderTrackerContext context)
        {
            _context = context;
        }

        // GET: api/Packages
        [HttpGet]
        public IEnumerable<Package> GetPackage()
        {
            return _context.Package;
        }

        // GET: api/Packages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPackage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var package = await _context.Package.FindAsync(id);

            if (package == null)
            {
                return NotFound();
            }

            return Ok(package);
        }

        // PUT: api/Packages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackage([FromRoute] int id, [FromBody] Package package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != package.Id)
            {
                return BadRequest();
            }

            _context.Entry(package).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageExists(id))
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

        // POST: api/Packages
        [HttpPost]
        public async Task<IActionResult> PostPackage([FromBody] Package package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Package.Add(package);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackage", new { id = package.Id }, package);
        }

        // DELETE: api/Packages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var package = await _context.Package.FindAsync(id);
            if (package == null)
            {
                return NotFound();
            }

            _context.Package.Remove(package);
            await _context.SaveChangesAsync();

            return Ok(package);
        }

        private bool PackageExists(int id)
        {
            return _context.Package.Any(e => e.Id == id);
        }
    }
}