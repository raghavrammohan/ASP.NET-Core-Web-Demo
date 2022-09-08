using AutoMapper;
using CWC.DocMgmt.Models;
using CWC.DocMgmtClient.DTO;

namespace CWC.DocMgmtClient.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DocInfoDTO, DocInfo>().ReverseMap();
    }
}