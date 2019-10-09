
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

        private ICustomer mgr;
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
            this.mgr = new Customer(mgrID.ToString(), mgrID.ToString(), "n/a");
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

        public ICustomer GetMgr()
        {
            return this.mgr;
        }

        public void MangeLocation()
        {
            //sentinel
            bool done = false;
            string choice = "none";

            while(!done)
            {
                Console.Clear();
                
                //prompt
                Console.WriteLine(ManageLocMenu() );
                
                //get the choice
                choice = Console.ReadLine();

                //logic for choice
                switch(choice)
                {
                    case "1":
                        Console.Clear();
                        PrintInv();
                        Console.WriteLine("Press Any Key To Exit:");
                        Console.ReadLine();
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Exiting");
                        break;
                }
            }
        }
        public string ManageLocMenu()
        {
            return ("\nWelcome Manager"
            + "\nPlease Choose One Of The Following"
            + "\n\n1. Store Inventory"
            + "\n2. Order History"
            + "\n3. Client List"
            + "\n4. Sales Reporting"   
            + "\n5. Exit Management Menu"
             );


        }

        private void PrintInv()
        {
            Console.WriteLine("Inventory On Hand");
            //visible format
            for (int i = 0; i < this.inventory.Count; i++)
            {
                Console.WriteLine($"Item: {this.inventory[i].GetTheName() } Quantity: { this.inventory[i].GetStockTotal() } ");
            }
        }

        private void PrintReciepts()
        {
            Console.WriteLine("Recent Orders");
            //visible format
            for (int i = 0; i < this.inventory.Count; i++)
            {
                
                Console.WriteLine($"Order {i}: Customer: { this.receipts[i].GetCustomer().GetPhone() }Qty Items Ordered: {this.receipts[i].ReturnTotalItems() } Sale: { this.receipts[i].GetTotal() } ");
            }
        }
    }
}
