using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryCRUD
{
    public abstract class BaseProductFactory
    {
        public abstract IProductPrice create();

        protected Product product;

        protected BaseProductFactory(Product product)
        {
            this.product = product;
        }

        public Product FinalPrice()
        {
            IProductPrice price = this.create();
            product.ProductionCost = price.GetProductionCost();
            product.PackagePrice = price.TotalCost();
            return product;
        }
    }
}
