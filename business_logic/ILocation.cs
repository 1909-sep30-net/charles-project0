using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic
{
    public interface ILocation
    {
        public void AddProduct(IProduct addMe);

        public void RemProduct(IProduct removeMe);
        public void AdjustInv(string prod, int qty);
    }
}
