using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic
{
    public interface IOrder
    {
        public void UpdateTotal(IProduct item);
        public double GetTotal();
        public void GetTodaysDate();
        public void AddItemToOrder();
        public void RemoveItemFromOrder();
        public int ReturnTotalItems();

        public ICustomer GetCustomer();
    }
}
