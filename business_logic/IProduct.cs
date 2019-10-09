using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic
{
    public interface IProduct
    {
        public double Profitability();

        public void AdjustQty(int adjustment);

        public string GetTheName();

        public int GetStockTotal();

        public double GetSalePrice();
    }
    
    
    
}
