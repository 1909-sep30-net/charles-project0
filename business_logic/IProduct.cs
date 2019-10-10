using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic
{
    public interface IProduct
    {
        //have to put this here as the properties block needs to get through the interface.
        public double salePrice { get; }
        public int QuantityOnHand { get; }

        public double Profitability();

        public void AdjustQty(int adjustment);

        public string GetTheName();

        public int GetStockTotal();

    }
    
    
    
}
