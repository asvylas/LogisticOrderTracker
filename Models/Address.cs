using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogisticOrderTracker.Models.BaseEntities;
using Microsoft.EntityFrameworkCore;

namespace LogisticOrderTracker.Models
{
    public class Address : Base
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public ICollection<AddressContact> Contacts { get; set; }

        public async Task<ICollection<AddressContact>> GetContacts(LogisticOrderTrackerContext context)
        {
            return await context.AddressContact.Where(e => e.Active == true && e.AddressId == this.Id).ToListAsync();
        }
    }
}