using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LogisticOrderTracker.Models;

namespace LogisticOrderTracker.Pages.Logistics.Forwarders.Contacts
{
    public class EditModel : PageModel
    {
        private readonly LogisticOrderTracker.Models.LogisticOrderTrackerContext _context;

        public EditModel(LogisticOrderTracker.Models.LogisticOrderTrackerContext context)
        {
            _context = context;
        }

        public int? ForwarderId { get; set; }

        [BindProperty]
        public ForwarderContact Contact { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? forwarder)
        {
            if (id == null || forwarder == null)
            {
                return NotFound();
            }

            ForwarderId = forwarder;
            Contact = await _context.ForwarderContact.FirstOrDefaultAsync(m => m.Id == id);

            if (Contact == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? forwarder)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Contact.ForwarderId = forwarder ?? default(int);
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

            return RedirectToPage("../Details", new { id = forwarder });
        }

        private bool ContactExists(int id)
        {
            return _context.ForwarderContact.Any(e => e.Id == id);
        }
    }
}
