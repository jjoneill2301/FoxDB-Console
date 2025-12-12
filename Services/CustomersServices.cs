using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxDB.Models;
using Microsoft.EntityFrameworkCore;

namespace FoxDB.Services
{
    public class CustomersServices
    {

        private readonly FoxContext _context;

        public CustomersServices(FoxContext context) => _context = context;

        public Customer? GetById(int id) =>
            _context.Customers
                    .AsNoTracking()
                    .FirstOrDefault(c => c.CustomerId == id);

        public IEnumerable<Customer> GetAll() =>
            _context.Customers
                    .AsNoTracking()
                    .OrderBy(c => c.CustomerId)
                    .ToList();

        public void Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateAll(Customer customer)
        {
            var existing = _context.Customers.Find(customer.CustomerId);
            if (existing == null)
                throw new InvalidOperationException("Customer not found");

            existing.FirstName = customer.FirstName;
            existing.LastName = customer.LastName;
            existing.Email = customer.Email;

            _context.SaveChanges();
        }

        public void UpdateFirstName(Customer customer)
        {
            var existing = _context.Customers.Find(customer.CustomerId);
            if (existing == null)
                throw new InvalidOperationException("Customer not found");

            existing.FirstName = customer.FirstName;
            _context.SaveChanges();
        }

        public void UpdateLastName(Customer customer)
        {
            var existing = _context.Customers.Find(customer.CustomerId);
            if (existing == null)
                throw new InvalidOperationException("Customer not found");

            existing.LastName = customer.LastName;
            _context.SaveChanges();
        }
        public void UpdateEmail(Customer customer)
        {
            var existing = _context.Customers.Find(customer.CustomerId);
            if (existing == null)
                throw new InvalidOperationException("Customer not found");

            existing.Email = customer.Email;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var existing = _context.Customers.Find(id);
            if (existing == null) return;

            _context.Customers.Remove(existing);
            _context.SaveChanges();
        }
    }
}
