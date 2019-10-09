using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic
{
    public class Product : IProduct
    {
        private long prodID { get; set; }
        private string productDesc { get; set; }
        private string salesBlurb { get; set; }
        private double cost { get; set; }
        private double salePrice { get; set; }
        private double saleValue { get; set; }

        private int quantityOnHand { get; set; }

        public Product(string desc, string sellwords, double cost)
        {
            this.prodID = 0;
            this.productDesc = desc;
            this.salesBlurb = sellwords;
            this.cost = cost;
            this.salePrice = cost * 1.5;
            this.saleValue = salePrice - cost;
            this.quantityOnHand = 0;
        }

        //initialize with a quantity.
        public Product(string desc, string sellwords, double cost, int qty)
        {
            this.prodID = 0;
            this.productDesc = desc;
            this.salesBlurb = sellwords;
            this.cost = cost;
            this.salePrice = cost * 1.5;
            this.saleValue = salePrice - cost;
            this.quantityOnHand = qty;
        }

        public double Profitability()
        {
            return this.salePrice - this.cost;
        }

        public void AdjustQty(int adjustment)
        {
            this.salePrice += adjustment;
        }

        public string GetTheName()
        {
            return this.productDesc;
        }

        public int GetStockTotal()
        {
            return this.quantityOnHand;
        }

        public double GetSalePrice()
        {
            return this.salePrice;
        }
    }
}
