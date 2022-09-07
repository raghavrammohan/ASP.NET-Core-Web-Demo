using AutoMapper;
using ProductClient.DTO;
using ProductModule.Models;

namespace ProductModule.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductDTO, Product>().ReverseMap();
        CreateMap<ProductCategoryDTO, ProductCategory>().ReverseMap();
        CreateMap<ProductInventoryDTO, ProductInventory>().ReverseMap();
    }
}