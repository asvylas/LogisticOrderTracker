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
    public class IndexModel : PageModel
    {
        private readonly LogisticOrderTracker.Models.LogisticOrderTrackerContext _context;

        public IndexModel(LogisticOrderTracker.Models.LogisticOrderTrackerContext context)
        {
            _context = context;
        }

        public IList<Address> Address { get;set; }

        public async Task OnGetAsync()
        {
            Address = await _context.Address.ToListAsync();
        }
    }
}
