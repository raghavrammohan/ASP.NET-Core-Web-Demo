using AutoMapper;
using ProductClient.DTO;

namespace ProductModule.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductDTO, Models.Product>().ReverseMap();
    }
}