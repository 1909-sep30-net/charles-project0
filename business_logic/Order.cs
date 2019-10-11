using System;
using System.Collections.Generic;
using System.Text;

//an order mean individual orders by individual customers : a receipt and it's data

namespace business_logic
{
    public class Order : IOrder
    {
        //unique id
        private long orderID;
        
        //who is buying
        private ICustomer cust;

        public ICustomer Cust
        {
            get
            {
                return this.cust;
            }
            private set
            {
                this.cust = value;
            }
        }
        
        //total cost of order
        private double totalCost;

        //whats being ordered and how much
        private List< Tuple< IProduct, int > > itemsOrdered;
        
        //total number of items on order
        private int qtyAllItems;

        //when was it ordered
        private int orderDate;

        //lock the order in before check-out
        private bool orderIsLocked;
        private bool orderFulfulled;
        
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
            this.totalCost += goods.Item1.SalePrice * goods.Item2;
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

    }
}
