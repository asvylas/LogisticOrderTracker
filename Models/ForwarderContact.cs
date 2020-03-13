using LogisticOrderTracker.Models.BaseEntities;

namespace LogisticOrderTracker.Models
{
    public class ForwarderContact : Contact
    {
        public int ForwarderId { get; set; }
    }
}