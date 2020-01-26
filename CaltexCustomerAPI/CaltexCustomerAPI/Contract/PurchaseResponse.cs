using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaltexCustomerAPI.Contract
{
    public class PurchaseResponse
    {
        public Guid CustomerId { get; set; }
        public string LoyaltyCard { get; set; }
        public DateTime TransactionDate { get; set; }

        public double DiscountApplied { get; set; }
        public double TotalAmount { get; set; }
        public double GrandTotal { get; set; }
        public double? PointsTotal { get; set; }
    }
}
