using LogisticOrderTracker.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogisticOrderTracker.Pages.Logistics.Forwarders
{
    public class IndexModel : PageModel
    {
        private readonly LogisticOrderTracker.Models.LogisticOrderTrackerContext _context;

        public IndexModel(LogisticOrderTracker.Models.LogisticOrderTrackerContext context)
        {
            _context = context;
        }

        public IList<Forwarder> Forwarder { get; set; }

        public async Task OnGetAsync()
        {
            Forwarder = await _context.Forwarder.ToListAsync();
        }
    }
}