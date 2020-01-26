using System;
using System.Collections.Generic;

namespace CaltexCustomerAPI.Models
{
    public partial class Promotion
    {
        public string PromotionId { get; set; }
        public string PromotionName { get; set; }
        public string Category { get; set; }
        public int PointsPerDollar { get; set; }
        public DateTime? DtmInserted { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
