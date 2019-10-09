using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic
{
    public interface IOrder
    {
        public void UpdateTotal(Tuple<IProduct, int> goods);
        public double GetTotal();
        public void GetTodaysDate();
        public void AddItemToOrder(IProduct item , int qty);
        public void RemoveItemFromOrder();
        public int ReturnTotalItems();

        public ICustomer GetCustomer();
    }
}
