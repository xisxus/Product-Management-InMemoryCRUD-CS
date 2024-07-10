using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryCRUD
{
    internal class Program
    {
        public static ProductRepository repository = new ProductRepository();
        static void Main(string[] args)
        {
			try
			{
                DoTask();
			}
			catch (Exception ex)
			{

                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private static void DoTask()
        {
            Console.WriteLine("\t\t\t\t~~~~~~~~MdShefain~~~~~~~~~~\r");
            Console.WriteLine("\t\t\t\t~~~~~~~~~1280899~~~~~~~~~~\r");

            Console.WriteLine("\t\t\t\tProduct Management System\r");
            Console.WriteLine("\t\t\t\t~~~~~~~~~~~~~~~~~~~~~~~~~\r");
            Console.WriteLine("\nHow many oparetion do you Want to perform\n");
            int count = Convert.ToInt32(Console.ReadLine());
            int oparetionNumber = 0;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("\n\t\t\t\tEnter Your Choice \n\t\t\t\tSelect -1\n\t\t\t\tCreate -2\n\t\t\t\tUpdate -3\n\t\t\t\tDelete -4\n");
                    oparetionNumber = Convert.ToInt32(Console.ReadLine());
                    switch (oparetionNumber)
                    {
                        case 1:
                            ShowAllProduct(null);
                            break;
                        case 2:
                            AddNewProduct();
                            break;
                        case 3:
                            UPdateProduct();
                            break;
                        case 4:
                            DeleteProduct();
                            break;
                        default:
                            Console.WriteLine("Invalid Option Chosen");
                            break;

                    }
                }
            }
        }

        private static void DeleteProduct()
        {
            Product deleProduct = new Product();
            Console.WriteLine("Enter Product Id u Want to Delete");
            deleProduct.Id = Convert.ToInt32(Console.ReadLine());
            deleProduct = repository.DeleteProduct(deleProduct.Id);

            Console.WriteLine("delete successfully");
            ShowAllProduct(deleProduct);
            ShowAllProduct(null);
        }

        private static void UPdateProduct()
        {

            Product UpPro = new Product();
            Console.WriteLine("enter id ");
            UpPro.Id = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("enter name");
            UpPro.Name = Console.ReadLine();

        EnterCate:
            Console.WriteLine("Enter Catagory - HINT : Dairy - 1, Confectionary - 2 ");
            string CataRead = Console.ReadLine();
            FoodCatagory Cata;
            try
            {
                Cata = (FoodCatagory)Enum.Parse(typeof(FoodCatagory), CataRead);
            }
            catch (Exception)
            {
                Console.WriteLine("invalid");
                goto EnterCate;
            }

            UpPro.Catagory = Cata;

        EnterType:
            Console.WriteLine("Enter Type - HINT : 1 Healthy, 2 UnHeathy");
            string typeRead = Console.ReadLine();
            Type type;
            try
            {
                type = (Type)Enum.Parse(typeof(Type), typeRead);
            }
            catch (Exception)
            {
                Console.WriteLine("invalid Try again");
                goto EnterType;
            }

            UpPro.Type = type;

            UpPro = repository.UpdateProduct(UpPro);
            
            ShowAllProduct(UpPro);

            
            ShowAllProduct(null);
        }

        private static void AddNewProduct()
        {
            
            Console.WriteLine("enter name");
            string Name = Console.ReadLine();

        EnterCate:
            Console.WriteLine("Enter Catagory - HINT : 1 Dairy, 2 Confectionary");
            string CataRead =Console.ReadLine();
            FoodCatagory Cata1;
            try
            {
                Cata1 = (FoodCatagory)Enum.Parse(typeof(FoodCatagory), CataRead);

            }
            catch (Exception)
            {
                Console.WriteLine("invalid");
                goto EnterCate;
            }


        EnterType:
            Console.WriteLine("Enter Type - HINT : 1  Healthy, 2 UnHeathy");
            string typeRead = Console.ReadLine();
            Type type;
            try
            {
                type = (Type)Enum.Parse(typeof(Type), typeRead);
            }
            catch (Exception)
            {
                Console.WriteLine("invalid Try again");
                goto EnterType;
            }

            Console.WriteLine("Enter Price");

            decimal p = Convert.ToDecimal(Console.ReadLine());

            Product product = new Product(type,0,Name, Cata1 ,p);

            BaseProductFactory baseProductFactory = new ProductManagerFactory().CreateFactory(product);
            baseProductFactory.FinalPrice();

            repository.AddNewProduct(product);

            ShowAllProduct(product);
            
            ShowAllProduct(null);
        }

        private static void ShowAllProduct(Product value)
        {
            IEnumerable<Product> products = repository.GetProduct();
            Console.WriteLine(string.Format("\n| {0,-3}| {1,-10}| {2,-15}| {3,-10}| {4,-5}| {5,7} | {6,2} |{7,12}|{8,8}| {9,10}|", "ID", "Name", "Catagory", "Type", "Price","ProCost", "Tax", "Preserve", "Package", "T.Cost"));
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            if (value == null)
            {
                foreach (Product item in products)
                {
                    Console.WriteLine(string.Format("| {0,-3}| {1,-10}| {2,-15}| {3,-10}| {4,-5}| {5,6}  | {6,2}  |   {7,3}      |   {8,-5}| {9,10}|", item.Id, item.Name, item.Catagory, item.Type, item.Price, item.ProductionCost, item.Tax, item.PreserveCost, item.PackagePrice, item.TotalCost));
                }
            }
            else
            {
                Console.WriteLine(string.Format("| {0,-3}| {1,-10}| {2,-15}| {3,-10}| {4,-5}| {5,6}  | {6,2}  |   {7,3}       |   {8,-5}| {9,10}|", value.Id, value.Name, value.Catagory, value.Type, value.Price, value.ProductionCost, value.Tax, value.PreserveCost, value.PackagePrice, value.TotalCost));
            }
            
        }
    }
}
