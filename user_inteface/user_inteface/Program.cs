﻿using System;
using System.Linq;
using System.Threading;
using business_logic;
using System.Collections.Generic;
using data_access.Entities;
using data_access;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace user_inteface
{
    class Program
    {
        /*
        /// <summary>
        /// Logger... to console at boot
        /// </summary>
        /// <param name="args"></param>
        public static readonly ILoggerFactory AppLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });
        */

        static void Main(string[] args)
        {

            //////////////////////Database Setup//////////////////////
            // Options for the database-interaction set here

            DbContextOptions<caproj0Context> options = new DbContextOptionsBuilder<caproj0Context>()

                //.UseLoggerFactory(AppLoggerFactory)
                .Options;


            //a reference to the database
            using var context = new caproj0Context(options);


            //test bit
            /*
            DisplayManagers(context);
            DisplayLocations(context);
            */
            Console.WriteLine("Customers");
            DisplayCustomers(context);
            /*
            Console.WriteLine("Products");
            DisplayProducts(context);
            Console.WriteLine("Inventories");
            DisplayAllInventories(context);
            Console.WriteLine("Orders");
            DisplayAllOrders(context);
            Console.WriteLine("Line Items");
            DisplayAllLineItems(context);
            */
            //            Console.WriteLine("Adding test customer...");
            //          AddCustToDB(context, "George", "Washington", "8991234567", "cherryTree");
            //        Console.WriteLine("Updated list of customers");
            //      DisplayCustomers(context);

            //Console.WriteLine("Looking up a specific customer");
            //data_access.Entities.Customer george = getCustRecord(context, "8991234567");

            //Console.WriteLine("Specific Customer Info");
            //Console.WriteLine($"{george.Fname} {george.Lname} : PH: {george.Phone} :ID {george.CustomerId} : PW{george.CustomerPw}");

            //Console.WriteLine("Adding an order to the database");
            //db         customer       location
            //addOrderToDB(context, "7892105577", "8168175802");
            string tempPhone = "7892105577";
            //Console.WriteLine("Customer orders from " + tempPhone);
            //GetCustOrdersFromDB(context, tempPhone);
            
            tempPhone = "5551234567";
            Console.WriteLine($"Orders Placed At This Location with Phone# {tempPhone}");
            GetLocOrdersFromDB(context, tempPhone);

            //confirm continuation
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();


            //TEMPORARY
            //set up location
            //after serialization, load the location information coded in.  This is temporary
            ILocation store = new Location("Downtown", 1, 12345, "pickleJar42");
            /*
            //sample products
            store.AddProduct(new Product( "circuits", "Sal's fine Circuits", 12.5 , 300 ) );
            store.AddProduct(new Product("cpucard", "BluberryCake Computer Board", 3.0 , 40));
            store.AddProduct(new Product("gears", "Greg's Gears", 0.5 , 3500));
            store.AddProduct(new Product("sensors", "Sallys's Sense-O-matic", 0.5 , 100));
            store.AddProduct(new Product("limbs", "Leg-Day Pre-Built Limbs", 20.00 , 160));
            store.AddProduct(new Product("casing", "Amanda's Attractive Titanium Casing", 30.00, 40));

            //sample customers
            store.AddClient(new Customer("Bruce", "Wayne", "5551234567", "12345") );
            store.AddClient(new Customer("Diana", "Callisto", "1267891057", "0000"));
            store.AddClient(new Customer("Ed", "Horse", "3571295978", "54321"));
            */




            //purely UI and temporary
            string manager = "Soupy";
            string product = "Robot";
            string service = "Sales";

            bool sentinel = true;

            /// <summary>
            /// Main Loop: controls flow of the console-program
            /// </summary>

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
                        //prompt for username and password
                        ManageCustomer(store);
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
                        while (count > 0 && !oktogo)
                        {
                            //check the password 
                            if (store.comparePW(Console.ReadLine()))
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


        static void ManageCustomer(ILocation store)
        {
            Console.WriteLine("Welcome!\n"
                + "Please enter \n"
                + "   your phone number "
                + "    and password.\n\n");

            Console.Write("Phone Number?  : \t");
            string phEntered = Console.ReadLine();

            //look up the customer
            //Phone number is the primary key!!!!!!!!!!!!!!!!!!! (Works for Wal-Greens and Kroger, works here, too)
            //declare who we're looking up
            ICustomer thisCustomer = GetTheCustomer(store, phEntered);

            //password protected account
            if (thisCustomer != null)
            {
                Console.Write("Please Enter Your Password: \t");
                string pwEntered = Console.ReadLine();


                //check the password
                int tries = 4;
                while (true)
                {
                    //out of tries?
                    if (tries == 0)
                    { break; }


                    //check the password 
                    if (pwValid(thisCustomer, pwEntered))
                    {
                        Console.Clear();
                        Console.WriteLine($"Welcome Back {thisCustomer.FName}!");
                        Thread.Sleep(1000);

                        string choice = "";

                        while (choice != "x" || choice != "X")
                        {
                            Console.Clear();
                            Console.WriteLine("Enter the corisponding number for choice and press Enter.\n"
                                        + "1. New Order\n"
                                        + "2. Order History\n"
                                        + "or enter X to exit:\t");

                            choice = Console.ReadLine();

                            if (choice == "1" || choice == "2")
                            {
                                switch (choice)
                                {
                                    case "1":
                                        Console.Clear();
                                        //display the order screen.
                                        orderScreen(store, thisCustomer);
                                        break;
                                    case "2":
                                        Console.Clear();
                                        Console.WriteLine(thisCustomer.RecieptsToStr());
                                        Console.WriteLine("Press Enter to Continue");
                                        string pause = Console.ReadLine();
                                        break;
                                }
                            }
                            else if (choice == "x" || choice == "X")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Choice");
                                Thread.Sleep(500);

                            }

                        }





                        Thread.Sleep(2000);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry.");
                        tries--;
                        Console.Write("Try again: ");
                        pwEntered = Console.ReadLine();
                        Thread.Sleep(2000);
                    }
                }
                //a pause

            }

        }

        //retrieve the customer object.///////////////////////////////////////////
        static ICustomer GetTheCustomer(ILocation store, string phEntered)
        {
            int sentinal = 4;

            while (sentinal > 0)
            {
                try
                {
                    Console.WriteLine($"Looking up account under {phEntered}");


                    return store.CustList.Find(entry => entry.PhoneNum == phEntered);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }

            return null;
        }

        static void MakeNewCustomer(ILocation store)
        {
            Console.Clear();
            //get sample input.
            Console.Write("First Name: \t");
            string fn = Console.ReadLine();

            Console.Write("Last Name: \t");
            string ln = Console.ReadLine();

            Console.Write("Cell Phone Number: \t");

            string cn = Console.ReadLine();

            // basic cybersecurity: have them answer it twice, compare, then use another method to record the password.
            // Not encrypted (for now)

            Console.Write("Enter a Password: \t");
            string pw1 = Console.ReadLine();
            Console.Write("Confirm your Password: \t");
            string pw2 = Console.ReadLine();

            //for old time's sake
            string RealDeal = new String("");

            while (true)
            {
                if (pw1 != pw2)
                {
                    Console.WriteLine("Password Entries Do Not Match");
                    Console.Write("Enter a Password: ");
                    pw1 = Console.ReadLine();
                    Console.Write("Confirm your Password: ");
                    pw2 = Console.ReadLine();
                }
                else
                {

                    //build the real password
                    for (int i = 0; i < pw1.Length; i++)
                    {
                        RealDeal += pw1[i];
                    }
                    break;
                }
            }



            //create the customer
            ICustomer customer = new business_logic.Customer(fn, ln, cn, RealDeal);

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
                //DATABSE INTEGRATION: before store stores a list of customer.
                //                     now    database gets a new entry.
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
                        customer.PhoneNum = Console.ReadLine();
                        break;
                    case "0":
                        sentinalConf = true;
                        Console.Clear();
                        Console.WriteLine($"Thank You, {customer.FName}, \nPlease log in at the main menu\nRecording Your Information...");

                        //confirmed as Factual so, add to the client-list.
                        store.AddClient(customer);

                        Thread.Sleep(3000);
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

        static bool pwValid(ICustomer cust, string entry)
        {
            if (entry == (cust.CustID))
            {
                //OK!
                return true;
            }

            //nope
            return false;
        }

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
                Console.WriteLine(store.LocMenuStr());


                //get the choice
                choice = Console.ReadLine();

                //logic for choice
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine(store.InvToStr());
                        Console.WriteLine("Press Enter To Exit:");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine(store.RecieptsToStr());
                        Console.WriteLine("Press Enter To Exit:");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine(store.ClientsToStr());
                        Console.WriteLine("Press Enter To Exit:");
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


        //Placing Orders and Documenting Orders///////////////////////////////////////////////////////////////
        //
        // Not covered here: billing, we'll assume everyone pays cash or in packs of gum.
        //

        //Location will probably need to retain this in business_logic
        static void orderScreen(ILocation store, ICustomer cust)
        {
            //prompt for an order
            string choice = "";

            Console.Clear();

            Console.Write("Enter another product or");

            //create the order
            //IOrder batOrder = new Order(cust); //never EVER use the default constructor...
            IOrder theOrder = new Order(cust); //never EVER use the default constructor...

            while (choice != "X" || choice != "x")
            {
                //refesh
                choice = "";

                Console.WriteLine(" enter X to exit.");

                Console.WriteLine(store.BuildMenuChoices());

                Console.WriteLine("Item Number: \t");

                choice = Console.ReadLine();

                if (choice == "X" || choice == "x")
                {
                    Console.WriteLine("Thank You! You have Ordered the following:\n");

                    //add to the store's list of reciepts (list of orders)
                    // valid order? 
                    if (theOrder != null && theOrder.ItemsOrdered.Count != 0)
                    {
                        /////////update store inventory////////////
                        // as order is confirmed, update customer's inventory.

                        //iterate over the order
                        for (int p = 0; p < theOrder.ItemsOrdered.Count; p++)
                        {
                            //adjust store inventory based on the order.
                            // Inventory stored in Product, so this is actually simple.
                            int quantity = theOrder.ItemsOrdered[p].Item2;
                            IProduct thisProduct = theOrder.ItemsOrdered[p].Item1;

                            //adjust the quanity, can go down to zero.
                            thisProduct.AdjustQty(-1 * quantity);

                            ///////////// output the order summary///////////////
                            //

                            Console.WriteLine($" Item: {thisProduct.ProductDesc} Qty: {quantity}\n");

                            //
                            /////////////////////////////////////////////////////
                        }

                        //
                        ///////////////////////////////////////

                        Console.WriteLine("Thank You For Your Business");
                        store.Reciepts.Add(theOrder);//to store reciepts

                        cust.CustOrders.Add(theOrder);//to customer history.

                        Console.WriteLine("Press Enter To Continue");
                        string pause = Console.ReadLine();

                    }
                    else
                    {
                        theOrder = null;
                        Console.WriteLine("Order canceled...");
                    }

                    return;
                }

                Console.Write("How many would you like to order today?\t");

                string qty = Console.ReadLine();


                //validate quantity ordered... not too many!
                if (Int32.Parse(qty) >= store.ProdIndex[Int32.Parse(choice)].QuantityOnHand)
                {
                    Console.WriteLine("Insufficient quantity on hand.\nTry to order something else!");
                    Thread.Sleep(1000);
                    qty = "0";
                }


                //create the order
                if (qty != "0")
                {
                    ////////////////////////THIS WORKS////////////////////////////////////
                    // For now, just add to the store's list of receipts....
                    // Check to see if it works ...

                    Console.WriteLine("Adding item to order...");

                    //add an order

                    //look up the product they want
                    //

                    IProduct thisProd = store.ProdIndex[Int32.Parse(choice)];

                    ///////////////////////

                    //add an item to that order.
                    //batOrder.AddItemToOrder(new Product("batarangs", "Steel Batarang", 5.0), Int32.Parse(qty) );
                    theOrder.AddItemToOrder(thisProd, Int32.Parse(qty));


                    //if place here, adds duplicates to the list of reciepts
                    //add to the store's list of reciepts (list of orders)
                    //store.Reciepts.Add(theOrder);

                    // TO ACCESS order line-item-tuple IN ORDER LIST DIRECTLY
                    // short name: string
                    // store.Reciepts[ store.Reciepts.Count - 1].ItemsOrdered[0].Item1.ProductDesc
                    // quantity: int
                    // store.Reciepts[ store.Reciepts.Count - 1].ItemsOrdered[0].Item2

                    //gets the items ordered
                    Tuple<IProduct, int> lineItem = theOrder.ItemsOrdered[theOrder.ItemsOrdered.Count - 1];

                    Console.WriteLine($"Confirming:  Item: { lineItem.Item1.ProductDesc } Quantity: { lineItem.Item2 } ");
                    Console.WriteLine("Press Enter to Continue");
                    string pause = Console.ReadLine();
                    //
                    ////////////////////////////////////////////////////////////////////////

                }

                Console.Clear();

                Console.Write("Enter another product or");

            }

        }


        //Temporary////query all the tables.///////////////////
        //to ensure data integrity and that writes are working.


        //query the managers
        static void DisplayManagers(caproj0Context context)
        {
            Console.WriteLine("Company Managers:");
            Console.WriteLine($"{"ID",12}{"LocationID",30}{"Password",20}");
            foreach (Manager mgr in context.Manager.Include(loc => loc.StoreLocation)) //fore each manager, also include the location.
            {
                //binds the variable as its data type.

                //as an integer
                int locID = Int32.Parse(string.Join("", mgr.StoreLocation.Select(lID => lID.LocationId)));

                //as a string
                //string locID = mgr.StoreLocation.Select(lID => lID.StoreName) ; //get the location ID then convert to string


                Console.WriteLine($"{mgr.ManagerId,12}{locID,30}{mgr.ManagerPw,20}");

            }
        }

        //absoloutely simplest way to query all locations...
        static void DisplayLocations(caproj0Context context)
        {
            Console.WriteLine("Location Table");

            Console.WriteLine($"{"LocationId",12}{"StoreName",30}{"Phone",15}{"Manager",10}");
            foreach (StoreLocation location in context.StoreLocation)
            {

                Console.WriteLine($"{location.LocationId,12}{location.StoreName,30}{location.Phone,15}{location.Manager,10}");
            }
        }


        //simple way to query the list of customers
        static void DisplayCustomers(caproj0Context context)
        {

            foreach (data_access.Entities.Customer cust in context.Customer)
            {

                Console.WriteLine($"{cust.Fname,12}{cust.Lname,30}{cust.Phone,15}{cust.CustomerId,10}");
            }
        }

        //query the products available from the company
        static void DisplayProducts(caproj0Context context)
        {

            foreach (data_access.Entities.Product prod in context.Product)
            {

                Console.WriteLine($"{prod.ProductId,4}{prod.Pname,15}{prod.SalesName,40}{prod.Cost,10}{prod.SalesPrice,15}");
            }
        }

        //query inventories
        //simple way to query the list of customers
        static void DisplayAllInventories(caproj0Context context)
        {
            Console.WriteLine($"{"LocationID",15}{"ProductID",15}{"Quantity",15}");

            foreach (data_access.Entities.Inventory inv in context.Inventory)
            {

                Console.WriteLine($"{inv.LocationId,15}{inv.ProductId,15}{inv.Quantity,15}");
            }
        }

        //query orders that exist
        static void DisplayAllOrders(caproj0Context context)
        {
            Console.WriteLine($"{"OrderID",10}{"Customer",25}{"Locations",30}{"Date&Time",30}");
            foreach (CustOrder ord in context.CustOrder)
            {
                string custName = ord.Customer.Fname + " " + ord.Customer.Lname;
                string locName = ord.Location.StoreName;

                Console.WriteLine($"{ord.OrderId,10}{custName,25}{locName,30}{ord.OrderDate,30}");
            }
        }

        static void DisplayAllLineItems(caproj0Context context)
        {
            Console.WriteLine($"{"OrderNo",10}{"ID",10}{"Product",25}{"Quantity",15}");
            foreach (LineItem item in context.LineItem)
            {
                string product = item.Product.Pname;
                long orderID = item.Order.OrderId;

                Console.WriteLine($"{orderID,10}{item.LineItemId,10}{product,25}{item.Quantity,15}");
            }
        }

        //Writes:: 
        //MUST HAVE
        //
        // Create new customer
        //      get data
        //      create object
        //      write object to server

        // Get Specific Customer

        //new customer on db, no pre-reqs or dependancies to set up either.
        //works
        static void AddCustToDB(caproj0Context context, string fName, string lName, string phone, string pw) //get data
        {
            //check if customer already exists based on phone number.
            //                                           
            if (context.Customer.Any(cust => cust.Phone == phone))
            {
                Console.WriteLine("Customer already exists, please log in.");
                return;
            }

            var newCust = new data_access.Entities.Customer //create object
            {

                Fname = fName,
                Lname = lName,
                Phone = phone,
                CustomerPw = pw
            };

            //add it to the Customer table
            context.Customer.Add(newCust); //write to table

            //commit changes
            context.SaveChanges(); //write to server.

        }

        //get specific customer from database, consider converting into a business_logic.Customer here.
        //WORKS
        static data_access.Entities.Customer getCustRecord(caproj0Context context, string phone)
        {

            var customer = context.Customer.FirstOrDefault(cust => cust.Phone == phone);

            if (customer == null)
            {
                Console.WriteLine("Customer not found, please try again or make a new login.");
                return null;
            }

            return customer;

        }

        // Create new order
        //      get customer
        //      get location
        //      get items
        //      write order
        //      write line items to order.

        //works

        static void addOrderToDB(caproj0Context context, string custPhone, string locPhone)
        {
            //datetime format
            //2019-10-14 00:00:00.000
            //string now = SQLTimeStamp();

            //get the customer id
            var customer = context.Customer.FirstOrDefault(cust => cust.Phone == custPhone);

            //get the store id.
            var location = context.StoreLocation.FirstOrDefault(loc => loc.Phone == locPhone);

            //check if input is valid.
            if (customer == null)
            {
                Console.WriteLine("Unable to create order, The customer's record does not exist.");
                return;
            }
            else if( location == null)
            {
                Console.WriteLine("Unable to create order: The location's record does not exist.");
                return;
            }

            //passes all checks, so proceed
            
            var order = new data_access.Entities.CustOrder //create object
            {
                CustomerId = customer.CustomerId,
                LocationId = location.LocationId,
                OrderDate = DateTime.Now //don't need to build this, already done.
            };

            //add to the table
            context.CustOrder.Add(order);

            //save changes.
            context.SaveChanges();
        }

        //works
        static void GetCustOrdersFromDB(caproj0Context context, string custPhone)
        {
            

            //linq query to get the orders by phone for customer
            var custOrds = from order in context.CustOrder
                           where (order.Customer.Phone == custPhone)
                           select order;

            //convert to list
            var strOrd = custOrds.ToList();

            //iterate over the list for easily retrievable and identifying information.
            for (int i = 0; i < strOrd.Count; i++)
            {
                string listToStr = strOrd[i].OrderId.ToString() ;
                string listToStr2 = strOrd[i].LocationId.ToString();
                string listToStr3 = strOrd[i].OrderDate.ToString();

                Console.WriteLine("Date:" + listToStr3 + " --  Location: " + listToStr2 + " --  OrderID:" + listToStr);

                //INSERT LINE ITEMS HERE
            }
            

        }

        static void GetLocOrdersFromDB(caproj0Context context, string locPhone)
        {

            //linq query to get the orders by phone for customer
            var custOrds = from order in context.CustOrder
                           where (order.Customer.Phone == locPhone)
                           select order;

            //convert to list
            var strOrd = custOrds.ToList();

            //iterate over the list for easily retrievable and identifying information.
            for (int i = 0; i < strOrd.Count; i++)
            {
                string listToStr = strOrd[i].OrderId.ToString();
                string listToStr2 = strOrd[i].LocationId.ToString();
                string listToStr3 = strOrd[i].OrderDate.ToString();
                string listToStr4 = strOrd[i].Customer.Phone;

                Console.WriteLine("Customer: " + listToStr4 +" -- Date:" + listToStr3 + " --  Location: " + listToStr2 + " --  OrderID:" + listToStr);

            }


        }


        //Create a line item per-order and add to db....
        static void addLineItemToDB(caproj0Context context, long order, int prodN, int qty )
        {
            //check if they exist
            var theOrder = context.CustOrder.FirstOrDefault(ord => ord.OrderId == order);

            var theProduct = context.Product.FirstOrDefault(prod => prod.ProductId == prodN);

            //check if order and products exist
            if (theOrder == null)
            {
                Console.WriteLine("Invalid order, canceling");
                return;
            }
            else if(theProduct == null)
            {
                Console.WriteLine("Invalid item, canceling");
                return;
            }

            var lineItem = new data_access.Entities.LineItem //create object
            {
                OrderId = order,
                ProductId = prodN,
                Quantity = qty 
            };

            context.LineItem.Add(lineItem);

            context.SaveChanges();

        }




        //whoops...
        static string SQLTimeStamp()
        {
            //T-SQL datetime format
            //2019-10-14 00:00:00.000

            return DateTime.Now.Year.ToString() + '-' 
                + DateTime.Now.Month.ToString() + '-'
                + DateTime.Now.Day.ToString() + ' '
                + DateTime.Now.Hour.ToString() + ':'
                + DateTime.Now.Minute.ToString() + ':'
                + DateTime.Now.Second.ToString() + '.'
                + DateTime.Now.Millisecond.ToString();
        }



    }
}
