using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DataContext context;

        public ProductsRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<Product> AddProduct(Product product)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            if (product == null)
                return false;
            context.Products.Remove(product);
            var success = await context.SaveChangesAsync() > 0;
            return success;
        }

        public async Task<Product> GetProductByCondition(Expression<Func<Product, bool>> expression)
        {
            return await context.Products.FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCondition(
            Expression<Func<Product, bool>> expression
        )
        {
            return await context.Products.Where(expression).ToListAsync();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var oldProduct = await context.Products.FirstOrDefaultAsync(x =>
                x.ProductId == product.ProductId
            );
            if (oldProduct == null)
                return null;

            oldProduct.ProductName = product.ProductName;
            oldProduct.Category = product.Category;
            oldProduct.UnitPrice = product.UnitPrice;
            oldProduct.QuantityInStock = product.QuantityInStock;

            await context.SaveChangesAsync();

            return oldProduct;
        }
    }
}
