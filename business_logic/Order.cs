using System;
using System.Collections.Generic;
using System.Text;

//an order mean individual orders by individual customers : a receipt and it's data

namespace business_logic
{
    public class Order : IOrder
    {
        //unique id
        private long orderID { get; set; }
        //who is buying
        private Customer cust { get; set; }
        
        //total cost of order
        private double totalCost;

        //whats being ordered and how much
        private List< Product > itemsOrdered;

        //when was it ordered
        private int orderDate { get; set; }

        //lock the order in before check-out
        private bool orderIsLocked { get; set; }
        private bool orderFulfulled { get; set; }
        public Order() // blank constructor
        {
            this.orderID = 0;//always the first one.
            this.cust = new Customer("n/a", "n/a", "n/a");//dummy entry
            this.totalCost = 0.0;
            this.orderDate = 14920101; //yyyymmdd, apparently columbus ordered this via his cell phone on the way from Spain.
            this.orderFulfulled = true;
            this.orderIsLocked = true;
        }

        public void UpdateTotal(IProduct item)
        {
            this.totalCost += item.GetSalePrice();
        }

        public double GetTotal()
        {
            return this.totalCost;
        }

        public void GetTodaysDate()
        {
            
        }

        public void AddItemToOrder()
        {
            ;
        }

        public void RemoveItemFromOrder()
        {
            ;
        }

        public int ReturnTotalItems()
        {
            return this.itemsOrdered.Count;
        }

        public ICustomer GetCustomer()
        {
            return this.cust;
        }
    }
}
