using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic
{
    public interface IOrder
    {
        public void updateTotal();
        public void getTodaysDate();
        public void addItemToOrder();
        public void removeItemFromOrder();

    }
}
