using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic
{
    interface ILocation
    {
        public void addProduct(long prodN, int qty);
        public void remProduct(long prodN, int qty);
        public void recieveInv(long prodN, int qty);
        public void adjustInv(long prodN, int qty);
    }
}
