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
            CreateMap<CategoryViewModel, Category>();
            CreateMap<SupplierViewModel, Supplier>();
            CreateMap<CustomerViewModel, Customer>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<OrderViewModel, Order>();


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