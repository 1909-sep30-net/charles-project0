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
                        MakeNewCustomer(store);

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

        ///Customer Management////////////////////////////////////////////////////////////
        //
        //  UI methods for interacting with Business Logic
        //

        static void MakeNewCustomer(ILocation store)
        {
            Console.Clear();
            //get sample input.
            Console.Write("First Name: ");
            string fn = Console.ReadLine();

            Console.Write("Last Name: ");
            string ln = Console.ReadLine();

            Console.Write("Cell Phone Number: ");

            string cn = Console.ReadLine();

            //####AT THIS POINT, CONSIDER RECORDING A PASSWORD##########

            //create the customer
            ICustomer customer = new Customer(fn, ln, cn);

            //confirm that data is correct.
            Console.WriteLine($"Welcome:{ customer.FName } {customer.LName } at {customer.PhoneNum }"
                            + "\nIs your information correct?\n 1: Yes, 2: No\n\n");

            string read = Console.ReadLine();
            bool sentinalConf = false;

            //
            //if it is a valid entry
            //added to location's client-list
            //otherwise is corrected

            //confirmed as valid
            if (read == "1")
            {
                Console.Clear();
                sentinalConf = true;
                Console.WriteLine($"Thank You, {customer.FName}, \nPlease log in at the main menu\n\nRecording your information...");

                //is passed by reference, so all changes from here on out affect the reference.
                store.AddClient(customer);

                Thread.Sleep(3000);
            }

            //enter and correct customer info or exit to main menu.
            while (!sentinalConf)
            {
                Console.Clear();
                Console.WriteLine("Please correct your information");
                Thread.Sleep(1000);
                string choice = "NOPE";

                Console.WriteLine($"Enter a Number for Correction or 0 to finish: "
                    + $"\n1: { customer.FName } "
                    + $"\n2. { customer.LName } "
                    + $"\n3. { customer.PhoneNum } " 
                    + "\n\nEnter 9 to Cancel and Exit");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Re-Enter your first-name: ");
                        customer.FName = Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Re-Enter your last-name: ");
                        customer.LName = Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Re-Enter your phone-number: ");
                        customer.PhoneNum = Console.ReadLine() ;
                        break;
                    case "0":
                        sentinalConf = true;
                        Console.Clear();
                        Console.WriteLine($"Thank You, {customer.FName}, \nPlease log in at the main menu\nRecording Your Information...");

                        //confirmed as Factual so, add to the client-list.
                        store.AddClient(customer);
                        break;
                    default:
                        //any other entry other than relevant choices lead to no-record and exit.
                        customer = null;
                        Console.Clear();
                        Console.WriteLine($"Thank You, \nCanceling and Returning to Main Menue...");
                        sentinalConf = true;
                        break;
                }

            }//end while loop

        }

        ///////end  new customer

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
                        Console.WriteLine( store.InvToStr() );
                        Console.WriteLine("Press Any Key To Exit:");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine( store.RecieptsToStr() );
                        Console.WriteLine("Press Any Key To Exit:");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine( store.ClientsToStr() );
                        Console.WriteLine("Press Any Key To Exit:");
                        Console.ReadLine();
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


        ///////////////////////////////////////// end store management UI//////////////

        //shortcut for pausing
        //NapTime(int time in milliseconds)
        static void NapTime(int time)
        { 
            Thread.Sleep(time);
        }

     

    }
}
