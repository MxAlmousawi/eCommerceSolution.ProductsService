using System.Linq.Expressions;
using AutoMapper;
using BuisnessLogicLayer.Dto;
using BuisnessLogicLayer.ServiceContracts;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;

namespace BuisnessLogicLayer.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository repo;

        public ProductsService(IMapper mapper, IProductsRepository repo)
        {
            Mapper = mapper;
            this.repo = repo;
        }

        public IMapper Mapper { get; }

        public async Task<ProductResponse> AddProduct(ProductAddRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var product = Mapper.Map<Product>(request);
            product = await repo.AddProduct(product);
            return Mapper.Map<ProductResponse>(product);
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            return await repo.DeleteProduct(id);
        }

        public async Task<ProductResponse> GetProductByCondition(
            Expression<Func<Product, bool>> expression
        )
        {
            var product = await repo.GetProductByCondition(expression);

            if (product == null)
                return null;

            return Mapper.Map<ProductResponse>(product);
        }

        public async Task<List<ProductResponse>> GetProducts()
        {
            var products = await repo.GetProducts();
            return Mapper.Map<List<ProductResponse>>(products);
        }

        public async Task<List<ProductResponse>> GetProductsByCondition(
            Expression<Func<Product, bool>> expression
        )
        {
            var products = await repo.GetProductsByCondition(expression);
            return Mapper.Map<List<ProductResponse>>(products);
        }

        public async Task<ProductResponse> UpdateProduct(ProductUpdateRequest request)
        {
            var updatedProduct = Mapper.Map<Product>(request);
            var result = await repo.UpdateProduct(updatedProduct);
            if (result == null)
                return null;

            return Mapper.Map<ProductResponse>(result);
        }
    }
}
