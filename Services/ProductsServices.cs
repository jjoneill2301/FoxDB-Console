using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxDB.Models;
using Microsoft.EntityFrameworkCore;

namespace FoxDB.Services
{
    public class ProductsServices
    {
        private readonly FoxContext _context;

        public ProductsServices(FoxContext context) => _context = context;

        public Product? GetById(int id) =>
            _context.Products
                    .AsNoTracking()
                    .FirstOrDefault(p => p.ProductId == id);

        public IEnumerable<Product> GetAll() =>
            _context.Products
                    .AsNoTracking()
                    .OrderBy(p => p.ProductId)
                    .ToList();

        public void Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateAll(Product product)
        {
            var existing = _context.Products.Find(product.ProductId);
            if (existing == null)
                throw new InvalidOperationException("Product not found");

            existing.ProductName = product.ProductName;
            existing.UnitPrice = product.UnitPrice;

            _context.SaveChanges();
        }

        public void UpdatePrice(Product product)
        {
            var existing = _context.Products.Find(product.ProductId);
            if (existing == null)
                throw new InvalidOperationException("Product not found");

            existing.UnitPrice = product.UnitPrice;
            _context.SaveChanges();
        }

        public void UpdateName(Product product)
        {
            var existing = _context.Products.Find(product.ProductId);
            if (existing == null)
                throw new InvalidOperationException("Product not found");

            existing.ProductName = product.ProductName;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var existing = _context.Products.Find(id);
            if (existing == null) return;

            _context.Products.Remove(existing);
            _context.SaveChanges();
        }
    }
}
