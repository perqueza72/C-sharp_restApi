using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductProject.API.Contexts;
using ProductProject.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using ProductProject.API.Utils;

namespace ProductProject.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product Get(int cityId)
        {
            return _context.Products
                    .Where(c => c.Id == cityId).FirstOrDefault();
        }

        public IEnumerable<Product> Get(string description)
        {
            return _context.Products
                .Where(p => p.Description.Contains(description));
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

        public IRepositoryResponse Update(int id, Product product)
        {
            if (!ProductExists(product.Id))
                return new RepositoryErrorResponse(new RepositoryError(message: CommonErrorMessage<Product>.ObjNotExist));

            var productUpdated = _context.Products.Update(product);

            _context.SaveChanges();

            return new RepositoryResponse(productUpdated.Entity);
        }

        public IRepositoryResponse Insert(Product product)
        {
            if (ProductExists(product.Id))
                return new RepositoryErrorResponse(new RepositoryError(message: CommonErrorMessage<Product>.ObjExist));
            _context.Products.Add(product);
            Save();
            return new RepositoryResponse();
        }


        public IRepositoryResponse Delete(int id)
        {
            var deleteProduct = _context.Products.Where(p => p.Id == id).FirstOrDefault();
            if (deleteProduct == null)
                return new RepositoryErrorResponse(new RepositoryError(message: CommonErrorMessage<Product>.ObjNotExist));

            _context.Products.Remove(deleteProduct);
            Save();
            return new RepositoryResponse();
        }

        public bool ProductExists(int cityId)
        {
            return _context.Products.Any(c => c.Id == cityId);
        }
    }
}
