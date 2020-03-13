using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LogisticOrderTracker.Models;

namespace LogisticOrderTracker.Pages.Logistics.Addresses
{
    public class DetailsModel : PageModel
    {
        private readonly LogisticOrderTracker.Models.LogisticOrderTrackerContext _context;
        private IList<AddressContact> contacts;

        public DetailsModel(LogisticOrderTracker.Models.LogisticOrderTrackerContext context)
        {
            _context = context;
        }

        public Address Address { get; set; }
        public IList<AddressContact> Contacts { get => contacts; set => contacts = value; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Address = await _context.Address.FirstOrDefaultAsync(m => m.Id == id);
            Contacts = await _context.AddressContact.Where(e => e.AddressId == Address.Id).ToListAsync();

            if (Address == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
