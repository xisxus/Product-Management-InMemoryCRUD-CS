using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryCRUD
{
    internal class ConfectionaryProductPrice : IProductPrice
    {
        public decimal GetProductionCost() 
        {
            return 500;
        }

        public decimal TotalCost()
        {
            return 450;
        }

        public decimal GetTax()
        {
            return 30;
        }

        public decimal GetTotal()
        {
            decimal d = GetProductionCost();
            decimal f = GetTax();
            decimal m = TotalCost();
            return d + f + m;
        }
    }
}
