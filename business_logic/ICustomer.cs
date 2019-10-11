using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic
{
    public interface ICustomer
    {
        
        public string PhoneNum { get; }

        string MakeString();

        void SetFavorite();

        public void MakeNewCustomer(ILocation store);

    }
}
