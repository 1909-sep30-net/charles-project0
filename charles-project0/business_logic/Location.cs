using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic
{
    class Location
    {
        private string locName { get; set; }
        private int region { get; set; }
        private List<Tuple<int, int>> inventory { get; set; }

        private void addProduct(int prodID, int qty)
        {
            this.inventory.Add( new Tuple<int, int>(prodID, qty) );
        }
    }
}
