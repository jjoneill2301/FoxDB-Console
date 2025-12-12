using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxDB.Models;
using FoxDB.Services;
namespace FoxDB.Menus
{
    internal class CustomersMenu
    {
        private readonly CustomersServices _customersServices;

        public CustomersMenu()
        {
        }

        public CustomersMenu(CustomersServices customersServices)
        {
            _customersServices = customersServices;
        }

        public void CMenu()
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
                    Console.WriteLine("First name >> ");
                    string fName = Console.ReadLine();
                    Console.WriteLine("Last name >> ");
                    string lName = Console.ReadLine();
                    Console.WriteLine("Email address >> ");
                    string email = Console.ReadLine();
                    Customer c = new Customer
                    {
                        Email = email,
                        FirstName = fName,
                        LastName = lName
                    };
                    _customersServices.Create(c);
                    break;
                case "2":
                    foreach (var i in _customersServices.GetAll())
                        Console.WriteLine("");
                    break;
                // Additional cases for Read, Update, Delete can be added here
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }


    }
}
