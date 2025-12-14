using FoxDB.Services;
using FoxDB.Models;
using FoxDB.Menus;
using Microsoft.Extensions.DependencyInjection; // install this package
namespace FoxDB
{
    // FOR LINQ
    // https://www.codecademy.com/learn/learn-c-sharp-lists-and-linq    // For PM Console
    /*
     * This worked for me...

Scaffold-DbContext "Server=PC\MSSQLSERVER01;Database=Fox;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force
    */
    
    internal class Program
    {
        
        static void Main(string[] args) 
        {
            // This is actually a great way to use main and keep it clean using a dependency container.
           var serviceProvider = new ServiceCollection()
               // .AddScoped AddDbContext AddTransient and buiilderserviceprovider are all from the DI Package Microsoft.Extensions.DependencyInjection
               // DI W/ Scoped lifetime for context
               .AddDbContext<FoxContext>()
               .AddScoped<CustomersServices>()
               .AddScoped<ProductsServices>()
               .AddScoped<OrdersServices>()
               //menu holds no data so make it transient
                .AddTransient<MainMenu>()
                .AddTransient<CustomersMenu>()
                .AddTransient<OrdersMenu>()
                .AddTransient<ProductsMenu>()
                //make immutable provider
                .BuildServiceProvider();

            //create scope
            using var scope = serviceProvider.CreateScope();
            //injects di into main
            var mainMenu = scope.ServiceProvider.GetRequiredService<MainMenu>();
            mainMenu.showMenu();
            
        }
    }
    






















}



