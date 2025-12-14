using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxDB.Models;
using FoxDB.Services;

namespace FoxDB.Menus
{
    public class OrdersMenu
    {
        private readonly OrdersServices _ordersServices;
        public OrdersMenu(OrdersServices ordersServices)
        {
            _ordersServices = ordersServices;
        }
        public void showMenu()
        {
            bool isOpen = true;
            while (isOpen)
            {
                Console.WriteLine("Select an option for Orders Table:");
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
            Console.WriteLine("Quantity:");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Customer ID Buying:");
            int custFK  = int.Parse(Console.ReadLine());
            Console.WriteLine("Buying Product with ID:");
            int prodFK = int.Parse(Console.ReadLine());
            Console.WriteLine("Unit Price:");
            double unitPrice = double.Parse(Console.ReadLine());
            DateOnly orderDate = DateOnly.FromDateTime(DateTime.Now);

            var order = new Order
            {
                Quantity = quantity,
                CustomerIdFk = custFK,
                ProductIdFk = prodFK,
                UnitPrice = unitPrice,
                OrderDate = orderDate
            };

            _ordersServices.Create(order);
            Console.WriteLine("Order created successfully.");
        }
        private void Read()
        {
            Console.WriteLine("Enter Order ID: ");
            try
            {
                int id = int.Parse(Console.ReadLine()); // make this int
                var order = _ordersServices.GetById(id);
                Console.WriteLine($"ID: {order.OrderId}" +
                                  $"\nCustomer ID: {order.CustomerIdFk}" +
                                  $"\nProduct ID: {order.ProductIdFk}" +
                                  $"\nQuantity: {order.Quantity}" +
                                  $"\nUnit Price: {order.UnitPrice}" +
                                  $"\nOrder Date: {order.OrderDate}");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Invalid ID format. Please enter a valid integer");
                Read();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Error retrieving order: Order ID does not exist.");
                Read();
            }
        }
        private void UpdateAll()
        {
            Console.WriteLine("Enter ID to update: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                var order = _ordersServices.GetById(id);

                Console.WriteLine("Enter new quantity: ");
                order.Quantity = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter new unit price: ");
                order.UnitPrice = double.Parse(Console.ReadLine());

                order.OrderDate = DateOnly.FromDateTime(DateTime.Now);
                _ordersServices.UpdateAll(order);
                Console.WriteLine("Order updated successfully.");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid ID format. Please enter a valid integer.");
                UpdateAll();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Error retrieving order: Order ID does not exist.");
                UpdateAll();
            }
        }
        private void Delete()
        {
            Console.WriteLine("Enter ID: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                var targetOrder = _ordersServices.GetById(id);
                _ordersServices.Delete(id);
                Console.WriteLine("Order deleted successfully.");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid ID format. Please enter a valid integer.");
                Delete();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Error deleting order: Order ID does not exist.");
                Delete();
            }
        }
    }
}
