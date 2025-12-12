using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxDB.Models;
using Microsoft.EntityFrameworkCore;

namespace FoxDB.Services
{
    public class OrdersServices
    {
        private readonly FoxContext _context;

        public OrdersServices(FoxContext context) => _context = context;

        public Order? GetById(int id) =>
            _context.Orders
                    .AsNoTracking()
                    .FirstOrDefault(o => o.OrderId == id);

        public IEnumerable<Order> GetAll() =>
            _context.Orders
                    .AsNoTracking()
                    .OrderBy(o => o.OrderId)
                    .ToList();

        public void Create(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void UpdateAll(Order order)
        {
            var existing = _context.Orders.Find(order.OrderId);
            if (existing == null)
                throw new InvalidOperationException("Order not found");

            existing.Quantity = order.Quantity;
            existing.UnitPrice = order.UnitPrice;
            existing.OrderDate = order.OrderDate;

            _context.SaveChanges();
        }

        public void UpdateQuantity(Order order)
        {
            var existing = _context.Orders.Find(order.OrderId);
            if (existing == null)
                throw new InvalidOperationException("Order not found");

            existing.Quantity = order.Quantity;
            
            _context.SaveChanges();
        }

        public void UpdatePrice(Order order)
        {
            var existing = _context.Orders.Find(order.OrderId);
            if (existing == null)
                throw new InvalidOperationException("Order not found");

            existing.UnitPrice = order.UnitPrice;

            _context.SaveChanges();
        }

        public void UpdateDate(Order order)
        {
            var existing = _context.Orders.Find(order.OrderId);
            if (existing == null)
                throw new InvalidOperationException("Order not found");

            existing.OrderDate = order.OrderDate;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var existing = _context.Orders.Find(id);
            if (existing == null) return;

            _context.Orders.Remove(existing);
            _context.SaveChanges();
        }
    }
}
