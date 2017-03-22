using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wool.Model;
using Wool.Web.ViewModels;

namespace Wool.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Product, ProductViewModel>();
        }

        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }
    }
}