using FoxDB.Services;
using FoxDB.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using Microsoft.IdentityModel.Tokens;
using FoxDB.Menus;
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
        const string CRUD = "Which CRUD operation are you performing?\n" +
                            "1) Create\n2) Read\n3) Update\n4) Delete";
        private readonly FoxContext _context;
        private readonly CustomersServices _customersServices;
        string input;

        public void Customers()
        {
            CustomersServices cs = new CustomersServices(_context);
            Console.WriteLine(CRUD);
            string input = Console.ReadLine();
            switch (int.Parse(input))
            {
                case 1:
                    Console.WriteLine("First name >> ");
                    string fName = Console.ReadLine();
                    Console.WriteLine("Last name >> ");
                    string lName = Console.ReadLine();
                    Console.WriteLine("Email address >> ");
                    string email = Console.ReadLine();
                    Customer c = new Customer();
                    c.Email = email;
                    c.FirstName = fName;
                    c.LastName = lName;
                    cs.Create(c);
                    break;
            }
        }
        static void Main(string[] args)
        {
            FoxContext _context = new FoxContext();
            Program p = new Program();
            CustomersMenu cm = new CustomersMenu();
            Console.Write("Which table are you performing CRUD on?\n" +
                          "1) Customers\n" +
                          "2) Orders\n" +
                          "3) Products\n");
            string input;
            input = Console.ReadLine();
            switch (int.Parse(input))
            {
                case 1:
                    //p.Customers();
                    cm.CMenu();
                    break;
                case 2:
                    Console.WriteLine(CRUD);
                    break;
                case 3:
                    Console.WriteLine(CRUD);
                    break;
            }
        }
    }
    






















}



