using System.Collections.Generic;
using LogisticOrderTracker.Models.BaseEntities;

namespace LogisticOrderTracker.Models
{
    public class Forwarder : Base
    {
        public string Name { get; set; }
        public ICollection<ForwarderContact> Contacts { get; set; }
    }
}