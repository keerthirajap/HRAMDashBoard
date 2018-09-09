
using AutoMapper;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Model;

namespace WebApp.Infrastructure
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        : this("ModelViewModelMappingProfie")
        {
        }
        protected AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {
            CreateMap<StoreModel, StoreViewModel>()
                .ForMember(dest => dest.StoreNo1,
               opts => opts.MapFrom(src => src.StoreNo))
               .ReverseMap() ;

            CreateMap<StoreServerViewModel, StoreServerModel>().ReverseMap();

        }
    }
}
