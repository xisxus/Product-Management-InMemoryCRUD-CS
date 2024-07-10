using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryCRUD
{
    public class Product
    {
        int id;
        string name;
        FoodCatagory catagory;
        Type type;
        decimal price;


        decimal tax;
        decimal preserveCost;
        decimal packagePrice;
        decimal productionCost;

        decimal totalCost;
        public Product()
        {
            
        }



        public Product(Type type, int id, string name, FoodCatagory catagory, decimal price = 0, decimal productionCost = 0)
        {
            this.Id = id;
            this.Name = name;
            this.Catagory = catagory;
            this.Type = type;
            this.price = price;
            this.productionCost = productionCost;
            
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public FoodCatagory Catagory { get => catagory; set => catagory = value; }
        public Type Type { get => type; set => type = value; }
        public decimal Price { get => price; set => price = value; }
        public decimal Tax { get => tax; set => tax = value; }
        public decimal PreserveCost { get => preserveCost; set => preserveCost = value; }
        public decimal PackagePrice { get => packagePrice; set => packagePrice = value; }
        public decimal ProductionCost { get => productionCost; set => productionCost = value; }
        public decimal TotalCost { get => totalCost; set => totalCost = value; }
    }
}
