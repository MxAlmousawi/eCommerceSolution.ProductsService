using AutoMapper;
using BuisnessLogicLayer.Dto;
using DataAccessLayer.Entities;

namespace BuisnessLogicLayer.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductAddRequest, Product>();
            CreateMap<ProductUpdateRequest, Product>();
            CreateMap<Product, ProductResponse>();
        }
    }
}
