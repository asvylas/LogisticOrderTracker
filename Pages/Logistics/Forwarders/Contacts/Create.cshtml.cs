using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LogisticOrderTracker.Models;
using LogisticOrderTracker.Models.BaseEntities;

namespace LogisticOrderTracker.Pages.Logistics.Forwarders.Contacts
{
    public class CreateModel : PageModel
    {
        private readonly LogisticOrderTracker.Models.LogisticOrderTrackerContext _context;

        public CreateModel(LogisticOrderTracker.Models.LogisticOrderTrackerContext context)
        {
            _context = context;
        }

        public int? ForwarderId { get; set; }

        public IActionResult OnGet(int? forwarder)
        {
            ForwarderId = forwarder ?? default(int);
            return Page();
        }

        [BindProperty]
        public ForwarderContact Contact { get; set; }

        public async Task<IActionResult> OnPostAsync(int? forwarder)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Contact.ForwarderId = forwarder ?? default(int);

            _context.ForwarderContact.Add(Contact);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Details", new { id = forwarder });
        }
    }
}