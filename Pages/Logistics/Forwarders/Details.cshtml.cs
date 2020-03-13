using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LogisticOrderTracker.Models;

namespace LogisticOrderTracker.Pages.Logistics.Forwarders
{
    public class DetailsModel : PageModel
    {
        private readonly LogisticOrderTracker.Models.LogisticOrderTrackerContext _context;
        private IList<ForwarderContact> contacts;

        public DetailsModel(LogisticOrderTracker.Models.LogisticOrderTrackerContext context)
        {
            _context = context;
        }

        public Forwarder Forwarder { get; set; }
        public IList<ForwarderContact> Contacts { get => contacts; set => contacts = value; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Forwarder = await _context.Forwarder.FirstOrDefaultAsync(m => m.Id == id);
            Contacts = await _context.ForwarderContact.Where(e => e.ForwarderId == Forwarder.Id).ToListAsync();

            if (Forwarder == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
