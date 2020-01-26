using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaltexCustomerAPI.Contract
{
    public class PurchaseRequest
    {
        public Guid CustomerId { get; set; }
        public string LoyaltyCard { get; set; }
        public DateTime TransactionDate { get; set; }

        public IList<BasketData> BasketData { get; set; }
    }
}
