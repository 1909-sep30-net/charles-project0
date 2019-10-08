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

        //noboody has a non-number phone number
        private int phoneNum { get; set; }

        //simple constructor
        public Customer(string first, string last, int phone)
        {

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

        public string GetlName()
        {
            return this.lName;
        }


        public int GetPhone()
        {
            return this.phoneNum;
        }



    }
}
