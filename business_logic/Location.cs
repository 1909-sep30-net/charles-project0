
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

        private List<ICustomer> custList;

        //list of reciepts
        private List<IOrder> receipts;

        //who runs the place?
        private long mgrID;
        private string mgrpwd;

        //is it on fire?
        public bool isOnFire = false;

        //constructor
        public Location(string name, int region, long ID, string log)
        {
            //basics
            this.locName = name;
            this.region = region;
            this.mgrID = ID;
            this.mgrpwd = log;
            
            //expandable, but for now, 1
            this.locID = 1;

            //set up the inventory list
            this.inventory = new List< IProduct >();

            //list of clientelle list
            this.custList = new List< ICustomer >();

            //set up the list of reciepts
            this.receipts = new List< IOrder > () ;

            //add the first product (which is nothing) for first product.
            // and empty store has nothing.
            IProduct blank = new Product("blank", "n/a", 0.0);
            this.inventory.Add(blank);

            //manager is the first client
            ICustomer mgr = new Customer(mgrID.ToString(), mgrID.ToString(), "n/a");
            this.custList.Add(mgr);//not a dummy to hold the first spot.

            //holds the first spot
            IOrder blankOrder = new Order();
            this.receipts.Add( blankOrder );
        }

        //REMOVE or change...unsecure
        public void PrintInfo()
        {
            Console.WriteLine( $"loc {this.locID} region {this.region} mgrpwd {this.mgrpwd}" );
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

        //add  a customer to the client list
        public void AddClient( ICustomer addMe)
        {
            this.custList.Add(addMe);
        }

        public void RemClient(ICustomer remMe)
        {
            this.custList.Remove( remMe );
        }

        public bool comparePW(string input)
        {
            if(input == this.mgrpwd)
            {
                return true;
            }
            return false;
        }



    }
}
