using LogisticOrderTracker.Models.BaseEntities;

namespace LogisticOrderTracker.Models
{
    public class Shipment : Base
    {
        public int Quantity { get; set; }
        public Package Package { get; set; }
    }
}