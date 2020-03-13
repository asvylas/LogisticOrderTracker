using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LogisticOrderTracker.Models;

namespace LogisticOrderTracker.Pages.Logistics.Forwarders.Contacts
{
    public class DeleteModel : PageModel
    {
        private readonly LogisticOrderTracker.Models.LogisticOrderTrackerContext _context;

        public DeleteModel(LogisticOrderTracker.Models.LogisticOrderTrackerContext context)
        {
            _context = context;
        }

        public int? ForwarderId { get; set; }

        [BindProperty]
        public ForwarderContact Contact { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? forwarder)
        {
            if (id == null)
            {
                return NotFound();
            }
            ForwarderId = forwarder ?? default(int);
            Contact = await _context.ForwarderContact.FirstOrDefaultAsync(m => m.Id == id);

            if (Contact == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, int? forwarder)
        {
            if (id == null)
            {
                return NotFound();
            }
            ForwarderId = forwarder ?? default(int);
            Contact = await _context.ForwarderContact.FindAsync(id);

            if (Contact != null)
            {
                _context.ForwarderContact.Remove(Contact);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../Details", new { id = forwarder });
        }
    }
}
