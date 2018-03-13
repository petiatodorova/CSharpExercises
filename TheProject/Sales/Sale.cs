using System;
using System.Collections.Generic;
using System.Text;

namespace Sales
{
    class Sale
    {
        public string Town { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public double Quantity { get; set; }

        public decimal TotalSales
        {
            get
            {
                return Price * (decimal)Quantity;
            }
        }
    }
}
