using System;
using System.Collections.Generic;

namespace CaltexCustomerAPI.Models
{
    public partial class Discount
    {
        public string DiscountId { get; set; }
        public string DiscountPromotionName { get; set; }
        public DateTime? DtmInserted { get; set; }
        public double Percent { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ProductId { get; set; }

        public virtual ProductDetails Product { get; set; }
    }
}
