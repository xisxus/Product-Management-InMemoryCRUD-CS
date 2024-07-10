using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryCRUD
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> productList;

        public ProductRepository()
        {
            productList = new List<Product>()
            { 
                new Product() { Id = 1 , Catagory = FoodCatagory.Dairy , Name = "Milk", Type = Type.Healthy, Price = 80 },
                new Product() { Id = 2 , Catagory = FoodCatagory.Dairy , Name = "Meat" , Type = Type.UnHeathy , Price = 800},
                new Product() { Id = 3 , Catagory = FoodCatagory.Dairy , Name = "Egg" , Type = Type.Healthy , Price = 130},
                new Product() { Id = 4 , Catagory = FoodCatagory.Confectionary , Name = "Biscuit" , Type = Type.Healthy , Price = 80},
                new Product() { Id = 5 , Catagory = FoodCatagory.Confectionary , Name = "Bread" , Type = Type.UnHeathy , Price = 80 },

            };

        }

        public Product AddNewProduct(Product product)
        {
            Product lastone = ((from a in  productList orderby a.Id descending select a).Take(1)).Single();
            product.Id = lastone.Id +1;
            productList.Add(product);
            return product;
        }

        public Product DeleteProduct(int id)
        {
            Product product = GetProductById(id);
            if (product != null)
            {
                productList.Remove(product);
            }
            return product;
        }

        public IEnumerable<Product> GetProduct()
        {
            return from a in productList select a;
        }

        public Product GetProductById(int id)
        {
            var product = (from a in productList where a.Id == id select a).Single();
            return product;
        }

        public Product UpdateProduct(Product UPproduct)
        {
            Product newProduct = GetProductById(UPproduct.Id);
            if(newProduct != null)
            {
                newProduct.Name = UPproduct.Name;
                newProduct.Catagory = UPproduct.Catagory;
                newProduct.Type = UPproduct.Type;
            }
            return newProduct;
        }
    }
}
