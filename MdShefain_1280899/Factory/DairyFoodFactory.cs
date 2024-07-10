using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryCRUD
{
    public class DairyFoodFactory : BaseProductFactory
    {
        Product produ;
        public DairyFoodFactory(Product product) : base(product)
        {
            produ = product;
        }

        public override IProductPrice create()
        {
            DairyProductPrice price = new DairyProductPrice();
            produ.PreserveCost = price.GetPreserveCost();
            produ.TotalCost = price.GetTotal();

            // TODO : method
            return price;
        }
    }
}
