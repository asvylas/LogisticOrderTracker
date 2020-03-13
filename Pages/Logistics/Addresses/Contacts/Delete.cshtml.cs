using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LogisticOrderTracker.Models;

namespace LogisticOrderTracker.Pages.Logistics.Addresses.Contacts
{
    public class DeleteModel : PageModel
    {
        private readonly LogisticOrderTracker.Models.LogisticOrderTrackerContext _context;

        public DeleteModel(LogisticOrderTracker.Models.LogisticOrderTrackerContext context)
        {
            _context = context;
        }

        public int? AddressId { get; set; }

        [BindProperty]
        public AddressContact Contact { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? address)
        {
            if (id == null)
            {
                return NotFound();
            }
            AddressId = address ?? default(int);
            Contact = await _context.AddressContact.FirstOrDefaultAsync(m => m.Id == id);

            if (Contact == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, int? address)
        {
            if (id == null)
            {
                return NotFound();
            }
            AddressId = address ?? default(int);
            Contact = await _context.AddressContact.FindAsync(id);

            if (Contact != null)
            {
                _context.AddressContact.Remove(Contact);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../Details", new { id = address });
        }
    }
}
