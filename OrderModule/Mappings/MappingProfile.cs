using AutoMapper;
using OrderClient.DTO;
using OrderModule.Models;

namespace OrderModule.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<OrderDTO, Order>().ReverseMap();
        CreateMap<OrderDetailsDTO, OrderDetails>().ReverseMap();
    }
}