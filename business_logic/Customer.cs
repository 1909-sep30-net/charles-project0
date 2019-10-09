using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace business_logic
{
    public class Customer: ICustomer
    {
        //unique id
        private long custID { get; set; }

        private string fName { get; set; }

        private string lName { get; set; }

        // phone number
        private string phoneNum { get; set; }

        //simple constructor
        public Customer(string first, string last, string phone)
        {
            //dynamically generate this.
            this.custID = 1;

            //get basic info
            this.fName = first;
            this.lName = last;
            this.phoneNum = phone;

        }

        public string MakeString()
        {
            //Fix this
            //quick and dirty, fix
            return this.ToString();
        }

        public void SetFavorite()
        {
            //Fix this.
            throw new NotImplementedException();
        }

        public string GetfName()
        {
            return this.fName;
        }

        public void SetfName(string change)
        {
            this.fName = change;
        }



        public string GetlName()
        {
            return this.lName;
        }

        public void SetlName(string change)
        {
            this.lName = change;
        }


        public string GetPhone()
        {
            return this.phoneNum;
        }

        public void SetPhone(string change)
        {
            this.phoneNum = change;
        }

        //overloaded...
        public void MakeNewCustomer(ILocation store)
        {
            //get sample input.
            Console.Clear();
            Console.Write("First Name: ");
            string fn = Console.ReadLine();

            Console.Write("Last Name: ");
            string ln = Console.ReadLine();

            Console.Write("Cell Phone Number: ");

            string cn = Console.ReadLine();

            Customer customer = new Customer(fn, ln, cn);

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
                
                //add a new client to the list
                store.AddClient(customer);
                
                Thread.Sleep(1000);
            }

            //enter customer's information from ui
            while (!sentinalConf)
            {
                Console.Clear();
                Console.WriteLine("Please correct your information");
                Thread.Sleep(1000);
                string choice = "NOPE";

                Console.WriteLine($"Enter a Number for Correction or 0 to finish: "
                    + $"\n1: { customer.GetfName() } "
                    + $"\n2. { customer.GetlName() } "
                    + $"\n3. { customer.GetPhone() } ");

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
            Thread.Sleep(3000);

        }

     

    }
}
