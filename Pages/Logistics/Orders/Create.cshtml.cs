using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LogisticOrderTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticOrderTracker.Pages.Logistics.Orders
{
    public class CreateModel : PageModel
    {
        private readonly LogisticOrderTracker.Models.LogisticOrderTrackerContext _context;

        public CreateModel(LogisticOrderTracker.Models.LogisticOrderTrackerContext context)
        {
            _context = context;
        }

        public IList<SelectListItem> Forwarders { get; set; }
        public IList<SelectListItem> Addresses { get; set; }
        public IList<SelectListItem> ProductManagers { get; set; }
        public IList<SelectListItem> Shipments { get; set; }



        [BindProperty]
        public int ForwarderId { get; set; }
        [BindProperty]
        public int ShipmentId { get; set; }
        [BindProperty]
        public int SenderId { get; set; }
        [BindProperty]
        public int ReceiverId { get; set; }
        [BindProperty]
        public int ProductManagerId { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Forwarders = await _context.Forwarder.Where(a => a.Active == true).Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Name
            }).ToListAsync();

            Addresses = await _context.Address.Where(a => a.Active == true).Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Name + e.City + e.Country + e.Street + e.Street
            }).ToListAsync();

            ProductManagers = await _context.ProductManager.Where(a => a.Active == true).Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Name
            }).ToListAsync();

            Shipments = await _context.Package.Where(a => a.Active == true).Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Type + "|" + e.Height.ToString() + "x" + e.Length.ToString() + "x" + e.Width.ToString() + "|" + e.Weight
            }).ToListAsync();


            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Order.Forwarder = await _context.Forwarder.Where(e => e.Id == ForwarderId).FirstOrDefaultAsync();
            Order.Receiver = await _context.Address.Where(e => e.Id == ReceiverId).FirstOrDefaultAsync();
            Order.Sender = await _context.Address.Where(e => e.Id == SenderId).FirstOrDefaultAsync();

            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}