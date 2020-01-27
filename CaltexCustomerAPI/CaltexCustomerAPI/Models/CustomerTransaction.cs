using System;
using System.Collections.Generic;

namespace CaltexCustomerAPI.Models
{
    public partial class CustomerTransaction
    {
        public CustomerTransaction()
        {
            TotalDetail = new HashSet<TotalDetail>();
        }

        public Guid CustomerId { get; set; }
        public string LoyaltyCard { get; set; }
        public DateTime? DtmTransaction { get; set; }
        public DateTime? DtmInserted { get; set; }

        public virtual ICollection<Basket> Basket { get; set; }
        public virtual ICollection<TotalDetail> TotalDetail { get; set; }
    }
}
