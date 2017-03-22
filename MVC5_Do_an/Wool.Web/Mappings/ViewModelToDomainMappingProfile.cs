using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wool.Model;
using Wool.Web.ViewModels;

namespace Wool.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductFormViewModel, Product>()
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.ProductTitle))
                .ForMember(g => g.Description, map => map.MapFrom(vm => vm.ProductDescription))
                .ForMember(g => g.Price, map => map.MapFrom(vm => vm.ProductPrice))
                .ForMember(g => g.CategoryID, map => map.MapFrom(vm => vm.ProductCategory))
                .ForMember(g => g.Brand, map => map.MapFrom(vm => vm.File.FileName));
        }

        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappings";
            }
        }
    }
}