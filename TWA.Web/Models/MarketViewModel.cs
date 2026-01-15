using TWA.Core.Entities;

namespace TWA.Web.Models
{
    public class MarketViewModel
    {
        public List<Village> Villages { get; set; } = new List<Village>();
        public int SelectedVillageId { get; set; }
        public Village? SelectedVillage { get; set; }
        public int AvailableMerchants { get; set; }
        public int TotalMerchants { get; set; }
        
        // Send Form
        public int TargetVillageId { get; set; }
        public int Wood { get; set; }
        public int Stone { get; set; }
        public int Iron { get; set; }
    }

    public class TransportsViewModel
    {
        public List<TransportItem> IncomingTransports { get; set; } = new List<TransportItem>();
        public List<TransportItem> OutgoingTransports { get; set; } = new List<TransportItem>();
    }

    public class TransportItem
    {
        public int Id { get; set; }
        public string OriginVillage { get; set; } = string.Empty;
        public string TargetVillage { get; set; } = string.Empty;
        public int Wood { get; set; }
        public int Stone { get; set; }
        public int Iron { get; set; }
        public int MerchantCount { get; set; }
        public DateTime ArrivalTime { get; set; }
        public bool CanCancel { get; set; }
    }
}
