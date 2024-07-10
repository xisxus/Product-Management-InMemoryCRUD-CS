using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryCRUD
{
    public class ConfectionaryFoodFactory : BaseProductFactory
    {
        Product prod;
        public ConfectionaryFoodFactory(Product product) : base(product)
        {
            prod = product;
        }

        public override IProductPrice create()
        {
            ConfectionaryProductPrice price = new ConfectionaryProductPrice();
            prod.Tax = price.GetTax();
            prod.TotalCost = price.GetTotal();

            //TODO : mehod 

            return price;
        }
    }
}
