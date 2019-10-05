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

            while (true)
            {

                Console.Write($"Welcome to {manager}'s {product} {service}\n");
                Console.WriteLine("Please make a choice");

                string choice = Console.ReadLine();

                switch(choice[0])
                {
                    case '1':
                        Console.Write("Welcome New Customer");
                        break;
                    case '2':
                        Console.Write("Please Log In :");
                        break;
                    case '3':
                        Console.Write("Please Log In :");
                        break;
                    default:
                        Console.Write("Please enter a valid choice");
                        Thread.Sleep(5000);
                        break;
                }
            }
        }
    }
}
