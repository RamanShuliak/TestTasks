using AutoMapper;
using SingleGetQuery.DataBase.Entities;
using SingleGetQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleGetQuery.Business.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductModel>()
                .ForMember(model => model.Name,
                opt => opt.MapFrom(ent => ent.Name))
                .ForMember(model => model.Price,
                opt => opt.MapFrom(ent => ent.Price))
                .ForMember(model => model.Category,
                opt => opt.MapFrom(ent => ent.Category.Name));
        }
    }
}
