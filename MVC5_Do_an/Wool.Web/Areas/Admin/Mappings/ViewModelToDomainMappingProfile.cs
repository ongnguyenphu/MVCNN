using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wool.Model;
using Wool.Web.Areas.Admin.ViewModels;

namespace Wool.Web.Areas.Admin.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CategoryViewModel, Category>()
                .ForMember(c => c.Name, map => map.MapFrom(vm => vm.Name));

            CreateMap<SupplierViewModel, Supplier>();
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