using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxDB.Models;
using FoxDB.Services;

namespace FoxDB.Menus
{
    public class ProductsMenu
    {
        private readonly ProductsServices _productsServices;
        public ProductsMenu(ProductsServices productsServices)
        {
            _productsServices = productsServices;
        }

        public void showMenu()
        {
            bool isOpen = true;
            while (isOpen)
            {
                Console.WriteLine("Select an option for Customers Table:");
                Console.WriteLine("1) Create");
                Console.WriteLine("2) Show");
                Console.WriteLine("3) Update");
                Console.WriteLine("4) Delete");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Create();
                        isOpen = false;
                        break;
                    case "2":
                        Read();
                        isOpen = false;
                        break;
                    case "3":
                        isOpen = false;
                        UpdateAll();
                        break;
                    case "4":
                        isOpen = false;
                        Delete();
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }

        }

        private void Create()
        {
            Console.WriteLine("Product Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Unit Price: ");
            double price = double.Parse(Console.ReadLine());
            
            var product = new Product
            {
                ProductName = name,
                UnitPrice = price
            };

            _productsServices.Create(product);
            Console.WriteLine("Product created successfully!");
        }

        private void Read()
        {
            Console.WriteLine("Enter Product ID: ");
            try
            {
                int id = int.Parse(Console.ReadLine()); // make this int
                var product = _productsServices.GetById(id);

                Console.WriteLine($"Product ID: {product.ProductId}");
                Console.WriteLine($"Product Name: {product.ProductName}");
                Console.WriteLine($"Product Price: {product.UnitPrice}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format. Please enter valid numbers.");
                Read();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Error retrieving product: ID does not exist.");
                Read();
            }
        }

        private void UpdateAll()
        {
            Console.WriteLine("Enter ID to update: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                var product = _productsServices.GetById(id);

                Console.Write("New Product Name: ");
                product.ProductName = Console.ReadLine();

                Console.Write("New Product Price: ");
                product.UnitPrice = double.Parse(Console.ReadLine());


                _productsServices.UpdateAll(product);
                Console.WriteLine("Product updated successfully.");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid format. Please enter valid numbers.");
                UpdateAll();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Error retrieving product: ID does not exist.");
                UpdateAll();
            }
        }

        private void Delete()
        {
            Console.WriteLine("Enter Product ID to delete: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                _productsServices.Delete(id);
                Console.WriteLine("Product deleted successfully.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid ID. Enter an integer.");
                Delete();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Error deleting product: ID does not exist.");
                Delete();
            }
        }
    }
}
