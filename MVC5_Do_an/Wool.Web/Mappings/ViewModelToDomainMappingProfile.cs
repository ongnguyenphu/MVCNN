using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wool.Model;
using Wool.Web.ViewModels;
using Wool.Web.ViewModels.Admin;

namespace Wool.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductFormViewModel, Product>()
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.ProductTitle))
                .ForMember(g => g.Description, map => map.MapFrom(vm => vm.ProductDescription))
                .ForMember(g => g.UnitPrice, map => map.MapFrom(vm => vm.ProductPrice))
                .ForMember(g => g.CategoryID, map => map.MapFrom(vm => vm.ProductCategory));

            CreateMap<CategoryViewModel, Category>()
                .ForMember(c => c.Name, map => map.MapFrom(vm => vm.Name));

            CreateMap<SupplierViewModel, Supplier>();


            #region Admin

            CreateMap<AdminSupplierViewModel, Supplier>();
            CreateMap<AdminProductViewModel, Product>();
            CreateMap<AdminCategoryViewModel, Category>();

            #endregion


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