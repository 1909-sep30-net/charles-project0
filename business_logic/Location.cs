
using System;
using System.Collections.Generic;
using System.Text;
//business location class
// inventory simply uses a list of tuples with a product number and the quantity on hand.

namespace business_logic
{
    public class Location : ILocation
    {
        //unique id
        private int locID { get; set; }
        private string locName { get; set; }
        private int region { get; set; }

        //product id, quantity
        private List<IProduct> inventory;

        //list of reciepts
        private List<IOrder> receiptNums;

        //who runs the place?
        private long mgrID;
        private string mgrpwd;

        //is it on fire?
        public bool isOnFire = false;

        //constructor
        public Location(string name, int region, long mgrID, string mgrpwd)
        {
            this.locID = 1;
            this.region = region;

            //set up the inventory
            this.inventory = new List< IProduct >();
            
            //add the first product (which is nothing) for first product.
            // and empty store has nothing. 
            
        }

        //add a product to inventory
        public void AddProduct( IProduct addMe )
        {
            this.inventory.Add( addMe );
        }

        //remove an item from inventory
        public void RemProduct( IProduct remMe)
        {
            this.inventory.Remove( remMe );
        }

        //adjust the quantity of an item in inventory.
        public void AdjustInv(string prod, int qty)
        {
            IProduct element = inventory.Find(e => e.GetTheName() == prod );

            element.AdjustQty(qty);

        }
    }
}
