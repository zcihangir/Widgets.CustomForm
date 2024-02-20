using AutoMapper;
using Grand.Infrastructure.Mapper;
using Widgets.CustomForm.Domain;
using Widgets.CustomForm.Models;

namespace Widgets.CustomForm.Infrastructure.Mapper
{
    public class CustomFormMapperConfiguration : Profile, IAutoMapperProfile
    {
        public CustomFormMapperConfiguration()
        {
            CreateMap<CustomFormModel, CustomFormDomain>()
                .ForMember(dest => dest.LimitedToStores, mo => mo.MapFrom(x => x.Stores != null && x.Stores.Any()))
                .ForMember(dest => dest.Locales, mo => mo.Ignore());

            CreateMap<CustomFormDomain, CustomFormModel>()
                .ForMember(dest => dest.Locales, mo => mo.Ignore());

            CreateMap<CustomFormInListModel, CustomFormDomain>()
                .ForMember(dest => dest.Locales, mo => mo.Ignore())
                .ForMember(dest => dest.Stores, mo => mo.Ignore());

            CreateMap<CustomFormDomain, CustomFormInListModel>()
                .ForMember(dest => dest.UserFields, mo => mo.Ignore());
        }
        public int Order {
            get { return 0; }
        }
    }
}
