using System;
using System.Threading;
using business_logic;

namespace user_inteface
{
    class Program
    {
        static void Main(string[] args)
        {      
            //TEMPORARY
            //set up location
            //after serialization, load the location information coded in.  This is temporary
            ILocation store = new Location( "Downtown", 1, 12345, "pickleJar42" );
            store.AddProduct(new Product( "circuits", "Sal's fine Circuits", 12.5 , 300 ) );
            store.AddProduct(new Product("cpucard", "BluberryCake Computer Board", 3.0 , 40));
            store.AddProduct(new Product("gears", "Greg's Gears", 0.5 , 3500));
            store.AddProduct(new Product("sensors", "Sallys's Sense-O-matic", 0.5 , 100));
            store.AddProduct(new Product("limbs", "Leg-Day Pre-Built Limbs", 20.00 , 160));
            store.AddProduct(new Product("casing", "Amanda's Attractive Titanium Casing", 30.00, 40));

           
            //purely UI and temporary
            string manager = "Soupy";
            string product = "Robot";
            string service = "Sales";

            bool sentinel = true;
            while (sentinel)
            {
                Console.Clear();

                Console.Write($"Welcome to {manager}'s {product} {service}\n");
                Console.WriteLine("Please make a choice");
                Console.WriteLine("1. Returning Customer\n"
                                + "2. New Customer\n\n\n"
                                + "3. ---->mgmt<----\n" //make this invisible....tie it to a different number.
                                + "4. Shutdown");


                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Welcome Returning Customer\n");
                        NapTime(1000);
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Welcome New Customer.\n\nPlease tell us\nwho you are, so we can process, your order effectively.\nLoading New Customer Menu\n...");
                        NapTime(3000);

                        //get the manager to make a new customer !
                        //had to use an end-run in order to follow separation of concerns for WHO makes the customer... 
                        //and the ui doesn't
                        store.GetMgr().MakeNewCustomer(store);

                        break;
                    case "3":
                        Console.Write("Please Log In :\n");
                        
                        //setup check
                        int count = 3;
                        bool oktogo = false;

                        //true true at first...
                        //count down number of attempts
                        //check the password entered
                        //fail at the third try (maybe later lock the system)
                        while(count > 0 && !oktogo)
                        {
                            //check the password 
                            if( store.comparePW( Console.ReadLine()) )
                            {
                                oktogo = true;

                                //manage the location
                                MangeLocation(store);
                                break;
                            }
                            Console.WriteLine("...nope...");
                            count--;
                        }
                        if (!oktogo)
                        {
                            Console.WriteLine("...failure, your tampering has been noted,\n     :) ");
                            NapTime(3000);
                        }
                        break;
                    case "4":
                        Console.Write("Shutting Down....\n");
                        sentinel = false;
                        NapTime(1000);
                        break;
                    default:
                        Console.Write("Please enter a valid choice");
                        NapTime(1000);
                        break;
                }
                
            }
        }//end main method

        ///////////////////////////////////////// Begin store management UI//////////////

        static public void MangeLocation(ILocation store)
        {
            //sentinel
            bool done = false;
            string choice = "none";

            while (!done)
            {
                Console.Clear();

                //prompt
                Console.WriteLine( store.LocMenuStr() );

                //get the choice
                choice = Console.ReadLine();

                //logic for choice
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        PrintInv(store);
                        Console.WriteLine("Press Any Key To Exit:");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        PrintReciepts(store);
                        Console.WriteLine("Press Any Key To Exit:");
                        Console.ReadLine();
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

        public static string ManageLocMenu()
        {
            return ("\nWelcome Manager"
            + "\nPlease Choose One Of The Following"
            + "\n\n1. Store Inventory" //need submenu
            + "\n2. Order History"     //need submenu
            + "\n3. Client List"       //
            + "\n4. Sales Reporting"
            + "\n5. Exit Management Menu"
             );


        }

        static void PrintInv(ILocation store)
        {
            Console.WriteLine("Inventory On Hand");
            //visible format
            for (int i = 0; i < store.GetInventory().Count; i++)
            {
                Console.WriteLine($"Item: {store.GetInventory()[i].GetTheName() } Quantity: { store.GetInventory()[i].QuantityOnHand } ");
            }
        }

        static void PrintReciepts(ILocation store)
        {
            Console.WriteLine("Recent Orders");
            //visible format
            for (int i = 0; i < store.GetReceipts().Count; i++)
            {

                Console.WriteLine($"Order {i}: Customer: { store.GetReceipts()[i].GetCustomer().GetPhone() } Qty Items: {store.GetReceipts()[i].ReturnTotalItems() } Sale: { store.GetReceipts()[i].GetTotal() } ");
            }
        }

        ///////////////////////////////////////// end store management UI//////////////

        //shortcut for pausing
        //NapTime(int time in milliseconds)
        static void NapTime(int time)
        { 
            Thread.Sleep(time);
        }

     

    }
}
