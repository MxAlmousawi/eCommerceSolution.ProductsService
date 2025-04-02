using System.Linq.Expressions;
using DataAccessLayer.Entities;

namespace DataAccessLayer.RepositoryContracts
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<Product>> GetProducts();
        public Task<IEnumerable<Product>> GetProductsByCondition(
            Expression<Func<Product, bool>> expression
        );
        public Task<Product> GetProductByCondition(Expression<Func<Product, bool>> expression);
        public Task<Product> AddProduct(Product product);
        public Task<Product> UpdateProduct(Product product);
        public Task<bool> DeleteProduct(Guid id);
    }
}
