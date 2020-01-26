using System;
using System.Collections.Generic;

namespace CaltexCustomerAPI.Models
{
    public partial class ProductDetails
    {
        public ProductDetails()
        {
            TblDiscount = new HashSet<Discount>();
        }

        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public double UnitPrice { get; set; }
        public DateTime? DtmInserted { get; set; }

        public virtual ICollection<Discount> TblDiscount { get; set; }
    }
}
