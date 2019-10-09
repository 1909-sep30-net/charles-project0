using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic
{
    public interface ICustomer
    {
        
        string MakeString();

        void SetFavorite();

        public string GetPhone();

        public void MakeNewCustomer(ILocation store);

    }
}
