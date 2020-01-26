using System;
using System.Collections.Generic;

namespace CaltexCustomerAPI.Models
{
    public partial class CustomerTransaction
    {
        public CustomerTransaction()
        {
            TblTotalDetail = new HashSet<TotalDetail>();
        }

        public Guid CustomerId { get; set; }
        public string LoyaltyCard { get; set; }
        public DateTime? DtmTransaction { get; set; }
        public DateTime? DtmInserted { get; set; }

        public virtual Basket TblBasket { get; set; }
        public virtual ICollection<TotalDetail> TblTotalDetail { get; set; }
    }
}
