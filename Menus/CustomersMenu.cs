// add confirmation, handling, and validation 

using FoxDB.Models;
using FoxDB.Services;

namespace FoxDB.Menus
{
    public class CustomersMenu
    {
        private readonly CustomersServices _customersServices;

        public CustomersMenu(CustomersServices customersServices)
        {
            _customersServices = customersServices;
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
            Console.WriteLine("first");
            string firstName = Console.ReadLine();
            Console.WriteLine("last");
            string lastName = Console.ReadLine();
            Console.WriteLine("email");
            string email = Console.ReadLine();

            var customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };

            _customersServices.Create(customer);
             Console.WriteLine("Customer created successfully!");
        }



            
        private void Read()
        {
            Console.WriteLine("Enter Customer ID: ");
            try
            {
                int id = int.Parse(Console.ReadLine()); // make this int
                var customer = _customersServices.GetById(id);

                Console.WriteLine($"ID: {customer.CustomerId}");
                Console.WriteLine($"First Name: {customer.FirstName}");
                Console.WriteLine($"Last Name: {customer.LastName}");
                Console.WriteLine($"Email: {customer.Email}");
            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid ID format. Please enter a valid integer.");
                Read();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Error retrieving customer: Customer ID does not exist.");
                Read();
            }
        }



        private void UpdateAll()
        {
            Console.WriteLine("Enter ID to update: ");
            try
            {                   
                int id = int.Parse(Console.ReadLine());                                                 
                var customer = _customersServices.GetById(id);

                Console.Write("New first name: ");
                customer.FirstName = Console.ReadLine();

                Console.Write("New last name: ");
                customer.LastName = Console.ReadLine();

                Console.Write("New email: ");
                customer.Email = Console.ReadLine();

                _customersServices.UpdateAll(customer);
                Console.WriteLine("Customer updated successfully.");
            }
            catch(FormatException e)
            {
                Console.WriteLine("Invalid ID format. Please enter a valid integer.");
                UpdateAll();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Error retrieving customer: Customer ID does not exist.");
                UpdateAll();
            }
        }




        private void Delete()
        {
            Console.WriteLine("Enter ID: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                _customersServices.Delete(id);
                Console.WriteLine("Customer deleted successfully.");
            }
            catch(FormatException e)
            {
                Console.WriteLine("Invalid ID format. Please enter a valid integer.");
                Delete();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Error deleting customer: Customer ID does not exist.");
                Delete();
            }
        }

    }
}
