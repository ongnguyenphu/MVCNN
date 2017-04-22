using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wool.Model;
using Wool.Web.Areas.Admin.ViewModels;

namespace Wool.Web.Areas.Admin.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Supplier, SupplierViewModel>();
            CreateMap<Product, ProductViewModel>()
                .ForMember(vm => vm.CategoryName, map => map.MapFrom(p => p.Category.Name))
                .ForMember(vm => vm.SupplierName, map => map.MapFrom(p => p.Supplier.Name));
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