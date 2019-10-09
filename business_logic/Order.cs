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
        private List< Tuple< IProduct, int > > itemsOrdered;

        private int qtyAllItems;

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
            this.itemsOrdered = new List< Tuple <IProduct , int > >();
            this.qtyAllItems = 0;
        }

        public void UpdateTotal( Tuple<IProduct, int> goods)
        {
            //Item sale price * number of items being ordered.
            this.totalCost += goods.Item1.GetSalePrice() * goods.Item2;
        }

        public double GetTotal()
        {
            return this.totalCost;
        }

        public void GetTodaysDate()
        {
            //time is irrelevant... for now;
        }

        public void AddItemToOrder(  IProduct item , int qty )
        {
            //make the new tuple
            Tuple<IProduct, int> itemVol = new Tuple<IProduct, int>(item, qty);
            
            //add the ordered pair to the order.
            itemsOrdered.Add( itemVol );
            
            //update totals
            this.qtyAllItems += qty;
            UpdateTotal( itemVol );
        }

        public void RemoveItemFromOrder()
        {
            //you touched it, you baught it!;
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
