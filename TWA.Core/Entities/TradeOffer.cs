using System;
using TWA.Core.Common;

namespace TWA.Core.Entities
{
    public class TradeOffer : BaseEntity
    {
        public string OfferId { get; set; }
        public string PlayerName { get; set; }
        public int OfferingWood { get; set; }
        public int OfferingStone { get; set; }
        public int OfferingIron { get; set; }
        
        public int AskingWood { get; set; }
        public int AskingStone { get; set; }
        public int AskingIron { get; set; }
        
        public double Ratio { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
