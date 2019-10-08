using System;
using System.Collections.Generic;
using System.Text;

//an order mean individual orders by individual customers : a receipt and it's data

namespace business_logic
{
    class Order
    {
        //unique id
        private long orderID { get; set; }
        //who is buying
        private Customer custID { get; set; }
        
        //total cost of order
        private double totalCost;

        //whats being ordered and how much
        private List< Product > currentOrder;

        //when was it ordered
        private int orderDate { get; set; }

        //lock the order in before check-out
        private bool orderIsLocked { get; set; }


    }
}
