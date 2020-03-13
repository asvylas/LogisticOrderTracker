using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LogisticOrderTracker.Models;
using LogisticOrderTracker.Models.BaseEntities;

namespace LogisticOrderTracker.Pages.Logistics.Addresses.Contacts
{
    public class CreateModel : PageModel
    {
        private readonly LogisticOrderTracker.Models.LogisticOrderTrackerContext _context;

        public CreateModel(LogisticOrderTracker.Models.LogisticOrderTrackerContext context)
        {
            _context = context;
        }

        public int? AddressId { get; set; }

        public IActionResult OnGet(int? address)
        {
            AddressId = address ?? default(int);
            return Page();
        }

        [BindProperty]
        public AddressContact Contact { get; set; }

        public async Task<IActionResult> OnPostAsync(int? address)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Contact.AddressId = address ?? default(int);

            _context.AddressContact.Add(Contact);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Details", new { id = address });
        }
    }
}