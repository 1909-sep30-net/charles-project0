using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic
{
    public class Product : IProduct
    {
        private long prodID;
        private string productDesc;
        private string salesBlurb;
        private double cost;
        public double salePrice { get; }
        private double saleValue;
        private int quantityOnHand;
        public int QuantityOnHand 
        { 
                get
                {
                    return this.quantityOnHand;
                }

                private set
                {
                    quantityOnHand = value;
                }
         }

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

            //markup is automatic (can be changed per business requirements)
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
            this.quantityOnHand += adjustment;
        }

        public string GetTheName()
        {
            return this.productDesc;
        }

        private void setQuantityOnHand( int adustment)
        {
            this.QuantityOnHand += adustment;
        }

        public int GetStockTotal()
        {
            return this.quantityOnHand;
        }

        private void SetSalePrice()
        {
            ;
        }

        public double GetSalePrice()
        {
            return this.salePrice;
        }
    }
}
