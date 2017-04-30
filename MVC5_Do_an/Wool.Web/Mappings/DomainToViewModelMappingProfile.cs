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
    public class DomainToViewModelMappingProfile : Profile
    {

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Supplier, SupplierViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Order, OrderViewModel>();


            #region Admin

            CreateMap<Category, AdminCategoryViewModel>();
            CreateMap<Supplier, AdminSupplierViewModel>();
            CreateMap<Product, AdminProductViewModel>();


            #endregion


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