using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BuisnessLogicLayer.Dto;
using DataAccessLayer.Entities;

namespace BuisnessLogicLayer.ServiceContracts
{
    public interface IProductsService
    {
        public Task<List<ProductResponse>> GetProducts();
        public Task<List<ProductResponse>> GetProductsByCondition(
            Expression<Func<Product, bool>> expression
        );
        public Task<ProductResponse> GetProductByCondition(
            Expression<Func<Product, bool>> expression
        );
        public Task<ProductResponse> AddProduct(ProductAddRequest request);
        public Task<ProductResponse> UpdateProduct(ProductUpdateRequest request);
        public Task<bool> DeleteProduct(Guid id);
    }
}
