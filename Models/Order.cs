using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LogisticOrderTracker.Models.BaseEntities;

namespace LogisticOrderTracker.Models
{
    public class Order : Base
    {
        public Address Receiver { get; set; }
        public Address Sender { get; set; }
        public Forwarder Forwarder { get; set; }
        public ICollection<Shipment> Shipments { get; set; }

        public Int64 ShipmentValue { get; set; }
        public ProductManager ProductManager { get; set; }

        [Column(TypeName = "text")]
        public string LoadingInstructions { get; set; }
        [Column(TypeName = "text")]
        public string UnloadingInstructions { get; set; }
        public string LoadingReferences { get; set; }
        public string UnloadingReferences { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ShipmentReady { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ShipmentArriving { get; set; }

        public string DriverPhone { get; set; }
        public string TruckNumber { get; set; }
        public Incoterms Incoterms { get; set; }
        public TransportType TransportType { get; set; }

        public bool SentToForwarder { get; set; } = false;
        public bool PaidForwarder { get; set; } = false;
        public bool ArrivedToWarehouse { get; set; } = false;
        public bool CMR { get; set; } = false;
        public bool POD { get; set; } = false;
    }

    public enum TransportType
    {
        Air,
        Sea,
        Road
    }

    public enum Incoterms
    {
        DAP,
        CTP,
        EXWORKS
    }
}