using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryCRUD
{
    public class ProductManagerFactory
    {
        public BaseProductFactory CreateFactory(Product product)
        {
            BaseProductFactory factory = null;
            if (product.Catagory == FoodCatagory.Dairy)
            {
                factory = new DairyFoodFactory(product);
            }
            else if (product.Catagory == FoodCatagory.Confectionary) 
            { 
                factory= new ConfectionaryFoodFactory(product);
            }
            return factory;
        }
    }
}
