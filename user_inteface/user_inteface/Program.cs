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
            //after serialization, load the location information
            ILocation store = new Location( "Downtown", 1, 12345, "pickleJar42" );

            store.PrintInfo();

            NapTime(3000);

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

                switch (choice[0])
                {
                    case '1':
                        Console.Write("Welcome Returning Customer\n");
                        NapTime(1000);
                        break;
                    case '2':
                        Console.Clear();
                        Console.Write("Welcome New Customer.\n\nPlease tell us\nwho you are, so we can process, your order effectively.\nLoading New Customer Menu\n...");
                        NapTime(3000);
                        MakeNewCustomer(store);

                        break;
                    case '3':
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
                                Console.WriteLine("Welcome Manager!");
                            }
                            Console.WriteLine("...nope...");
                            count--;
                        }
                        if (!oktogo)
                        {
                            Console.WriteLine("...failure, your tampering has been noted... :) ");
                        }

                        NapTime(3000);
                        break;
                    case '4':
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

        //shortcut for pausing
        //NapTime(int time in milliseconds)
        static void NapTime(int time)
        { 
            Thread.Sleep(time);
        }

        static void MakeNewCustomer(ILocation store)
        {
            //get sample input.
            Console.Clear();
            Console.Write("First Name: ");
            string fn = Console.ReadLine();
            
            Console.Write("Last Name: ");
            string ln = Console.ReadLine();
            
            Console.Write("Cell Phone Number: ");

            string cn = Console.ReadLine();

            Customer customer = new Customer(fn,ln,cn);

            //confirm that data is correct.
            Console.WriteLine($"Welcome:{ customer.GetfName() } {customer.GetlName() } at {customer.GetPhone() }"
                            + "\nIs your information correct?\n 1: Yes, 2: No\n\n");
            
            string read = Console.ReadLine();
            bool sentinalConf = false;

            if (read == "1")
            {
                Console.Clear();
                sentinalConf = true;
                Console.WriteLine("Thank You.\nRecording your information...");
                store.AddClient(customer);
                NapTime(1000);
            }

            //enter customer's information from ui
            while(!sentinalConf)
            {
                Console.Clear();
                Console.WriteLine("Please correct your information");
                NapTime(1000);
                    string choice = "NOPE";
                    
                    Console.WriteLine($"Enter a Number for Correction or 0 to finish: "
                        + $"\n1: { customer.GetfName() } "
                        + $"\n2. { customer.GetlName() } "
                        + $"\n3. { customer.GetPhone() } " );

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Re-Enter your first-name: ");
                        customer.SetfName(Console.ReadLine());

                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Re-Enter your last-name: ");
                        customer.SetlName(Console.ReadLine());


                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Re-Enter your phone-number: ");
                        customer.SetPhone(Console.ReadLine());


                        break;
                    case "0":
                        sentinalConf = true;
                        break;
                    default:
                        sentinalConf = true;
                        break;
                }

            }//end while loop
            Console.Clear();
            Console.WriteLine($"Thank You, {customer.GetfName()}, \nPlease log in at the main menu\nLoading..");
            NapTime(3000);
            //stub here
            //correct entry and store customer.

        }

    }
}
