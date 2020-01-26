using System;
using System.Collections.Generic;

namespace CaltexCustomerAPI.Models
{
    public partial class TotalDetails
    {
        public int TotalD { get; set; }
        public Guid CustomerId { get; set; }
        public double GrandTotal { get; set; }
        public int? PointsTotal { get; set; }
        public DateTime? DtmInserted { get; set; }

        public virtual CustomerTransaction Customer { get; set; }
    }
}
