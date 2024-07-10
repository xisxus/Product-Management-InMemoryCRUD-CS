using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryCRUD
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProduct();

        Product GetProductById(int id);

        Product DeleteProduct(int id);

        Product AddNewProduct(Product product);

        Product UpdateProduct(Product UPproduct);
    }
}
