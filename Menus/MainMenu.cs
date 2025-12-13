using FoxDB.Services;
using static System.Console;
using Microsoft.Extensions.DependencyInjection;

namespace FoxDB.Menus
{
    public class MainMenu
    {
      // Communicates with your DI Container (Built in interface) - Interfaces are the WHAT not the HOW
        private readonly IServiceProvider _serviceProvider;

        public MainMenu(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void showMenu()
        {
          bool isOpen = true;
          while (isOpen)
          {
            WriteLine("Management Menu enter 1-3: ");
            WriteLine("1 Customers Menu");
            WriteLine("2 Products Menu");
            WriteLine("3 Orders Menu");
            string input = ReadLine();
            switch (input)
                {
                    case "1":
                        var customersMenu = _serviceProvider.GetRequiredService<CustomersMenu>();
                // can just call showMenu can keep them same name because its clear with the intention by the way u call it "customersMenu".showMenu 
                        customersMenu.showMenu();
                        break;
                    //case "2":
                    //    var ordersMenu = _serviceProvider.GetRequiredService<OrdersMenu>();
                    //    ordersMenu.showMenu();
                    //    break;
                    //case "3":
                    //    var productsMenu = _serviceProvider.GetRequiredService<ProductsMenu>();
                    //    productsMenu.showMenu();
                    //    break;
                    default:
                        WriteLine("\nGoodbye!");
                        isOpen = false;
                        break;
                }
            }
        }
    }
}
