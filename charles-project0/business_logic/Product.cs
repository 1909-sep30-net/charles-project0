using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic
{
    class Product: IProduct
    {
        private long prodID { get; set; }
        private string productDesc { get; set; }
        private string salesBlurb { get; set; }
        private double cost { get; set; }
        private double salePrice { get; set; }
        private double saleValue { get; set; }

        public double Profitability()
        {
            return this.salePrice - this.cost;
        }
    }
}
