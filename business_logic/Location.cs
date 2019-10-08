
using System;
using System.Collections.Generic;
using System.Text;
//business location class
// inventory simply uses a list of tuples with a product number and the quantity on hand.

namespace business_logic
{
    class Location: ILocation
    {
        //unique id
        private int locID { get; set; }
        private string locName { get; set; }
        private int region { get; set; }

        //product id, quantity
        private List< Tuple<long, int> > inventory;

        //list of reciepts
        private List< long > receiptNums;

        //who runs the place?
        private long mgrID;

        //is it on fire?
        public bool isOnFire = false;

        private void addProduct(long prodID, int qty)
        {
            this.inventory.Add( new Tuple<long, int>(prodID, qty) );
        }

        void ILocation.addProduct(long prodN, int qty)
        {
            throw new NotImplementedException();
        }

        public void remProduct(long prodN, int qty)
        {
            throw new NotImplementedException();
        }

        public void recieveInv(long prodN, int qty)
        {
            throw new NotImplementedException();
        }

        public void adjustInv(long prodN, int qty)
        {
            throw new NotImplementedException();
        }
    }
}
