using System;
using System.Threading;
using business_logic;

namespace user_inteface
{
    class Program
    {
        static void Main(string[] args)
        {
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
                                + "3. ---->mgmt<----\n"
                                + "4. Shutdown");


                string choice = Console.ReadLine();

                switch (choice[0])
                {
                    case '1':
                        Console.Write("Welcome Returning Customer\n");
                        NapTime(1000);
                        break;
                    case '2':
                        Console.Write("Please Tell Us\nWho You Are :\n");
                        NapTime(1000);

                        break;
                    case '3':
                        Console.Write("Please Log In :\n");
                        NapTime(1000);
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

        static void GetCustomer()
        {
            //get sample input.
            Console.Clear();
            Console.Write("First Name: ");
            string fn = Console.ReadLine();
            
            Console.Write("Last Name: ");
            string ln = Console.ReadLine();
            
            Console.Write("Cell Phone Number: ");
            string cns = Console.ReadLine();
            
            int cn = Int32.Parse(cns);
            Customer sample = new Customer(fn,ln,cn);

            //confirm that data is correct.
            Console.WriteLine($"Welcome:{ sample.GetfName() } {sample.GetlName() } at {sample.GetPhone() }"
                            + "Is your information correct?\n 1: Yes, 2: No\n\n");
            
            string read = Console.ReadLine();

            bool sentinalConf = false;
            while(!sentinalConf)
            { 
                
                if ( read == "1")
                {
                    sentinalConf = true;
                }
            }
            Console.WriteLine("Thank You, {}")
            //stub here
            //correct entry and store customer.

        }

    }
}
