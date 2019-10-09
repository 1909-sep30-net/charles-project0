using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic
{
    public interface ILocation
    {
        public void AddProduct(IProduct addMe);
        public void PrintInfo();
        public void RemProduct(IProduct removeMe);
        public void AdjustInv(string prod, int qty);

        public void AddClient(ICustomer addMe);

        public bool comparePW(string input);
    }
}
