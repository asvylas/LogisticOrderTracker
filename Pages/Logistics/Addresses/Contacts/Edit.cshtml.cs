using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LogisticOrderTracker.Models;

namespace LogisticOrderTracker.Pages.Logistics.Addresses.Contacts
{
    public class EditModel : PageModel
    {
        private readonly LogisticOrderTracker.Models.LogisticOrderTrackerContext _context;

        public EditModel(LogisticOrderTracker.Models.LogisticOrderTrackerContext context)
        {
            _context = context;
        }

        public int? AddressId { get; set; }

        [BindProperty]
        public AddressContact Contact { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? address)
        {
            if (id == null || address == null)
            {
                return NotFound();
            }

            AddressId = address;
            Contact = await _context.AddressContact.FirstOrDefaultAsync(m => m.Id == id);

            if (Contact == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? address)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Contact.AddressId = address ?? default(int);
            _context.Attach(Contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(Contact.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Details", new { id = address });
        }

        private bool ContactExists(int id)
        {
            return _context.AddressContact.Any(e => e.Id == id);
        }
    }
}
