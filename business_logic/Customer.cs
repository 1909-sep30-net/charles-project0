using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace business_logic
{
    public class Customer: ICustomer
    {
        //fields
        private long custID;

        public long CustID
        {
            get
            {
                return this.custID;
            }
            set
            {
                this.custID = value;
            }
        }
        private string fName;
        public string FName
        {
            get
            {
                return this.fName;
            }
            set
            {
                this.fName = value;
            }
        }
        private string lName;

        public string LName
        {
            get
            {
                return this.lName;
            }
            set
            {
                this.lName = value;
            }
        }
        

        private string phoneNum;
        public string PhoneNum
        {
            get
            {
                return this.phoneNum;
            }
            set
            {
                this.phoneNum = value;
            }
        }

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



    }
}
