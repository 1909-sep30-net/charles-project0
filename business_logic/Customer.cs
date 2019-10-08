using System;
using System.Collections.Generic;
using System.Text;

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


    }
}
