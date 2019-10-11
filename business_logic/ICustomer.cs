using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic
{
    public interface ICustomer
    {
        
        public string PhoneNum { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }

        public string CustID { get; set; }

        string MakeString();

        void SetFavorite();

    }
}
