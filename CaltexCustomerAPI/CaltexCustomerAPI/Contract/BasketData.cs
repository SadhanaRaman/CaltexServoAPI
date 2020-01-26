using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaltexCustomerAPI.Contract
{
    public class BasketData
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}
