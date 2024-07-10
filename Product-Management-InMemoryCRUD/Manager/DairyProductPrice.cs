using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryCRUD
{
    public class DairyProductPrice : IProductPrice
    {
        
        public decimal GetProductionCost()
        {
            return 520;
        }

        public decimal TotalCost()
        {
            return 500;
        }

        public decimal GetPreserveCost()
        {
            return 300;
        }

        public decimal GetTotal()
        {
            
            decimal d = TotalCost();
            decimal f = GetPreserveCost();
            decimal m = GetProductionCost();
            return d + f + m ;
        }
    }
}
