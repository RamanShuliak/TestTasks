using AutoMapper;
using ShortLinks.Core;
using ShortLinks.DataBase;
using ShortLinks.Models;

namespace ShortLinks.MappingProfile
{
    public class LinkProfile : Profile
    {
        public LinkProfile()
        {
            CreateMap<Link, LinkDto>().ReverseMap();

            CreateMap<CreateLinkModel, LinkDto>();

            CreateMap<CreateLinkModel, LinkDto>()
                .ForMember(dto => dto.Id,
                opt => opt.MapFrom(model => "Default"));
        }
    }
}
