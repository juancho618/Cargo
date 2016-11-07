using AutoMapper;
using Cargo.Data.Entities;
using Cargo.Domain.ViewModels.Parametrizacion;

namespace Cargo.Data.Mappings
{
    public class MapperConfigurationFromModel : Profile
    {
        protected override void Configure()
        {
            #region Parametrization
            CreateMap<UnitType, UnitTypeViewModel>()
                .ForMember(vm => vm.Id, map => map.MapFrom(m => m.UnitTypeId))
                .ForMember(vm => vm.Name, map => map.MapFrom(m => m.UnitName))
                .ForMember(vm => vm.Active, map => map.MapFrom(m => m.Active))
                .ForMember(vm => vm.Deleted, map => map.MapFrom(m => m.Deleted));

            CreateMap<Country, CountryViewModel>()
                .ForMember(vm => vm.Id, map => map.MapFrom(m => m.CountryID))
                .ForMember(vm => vm.Name, map => map.MapFrom(m => m.CountryName))
                .ForMember(vm => vm.Active, map => map.MapFrom(m => m.Active))
                .ForMember(vm => vm.Deleted, map => map.MapFrom(m => m.Deleted));

            CreateMap<Origin, OriginViewModel>()
                .ForMember(vm => vm.Id, map => map.MapFrom(m => m.OriginId))
                .ForMember(vm => vm.Name, map => map.MapFrom(m => m.OriginName))
                .ForMember(vm => vm.Active, map => map.MapFrom(m => m.Active))
                .ForMember(vm => vm.Deleted, map => map.MapFrom(m => m.Deleted));

            CreateMap<Branch, BranchViewModel>()
                .ForMember(vm => vm.Id, map => map.MapFrom(m => m.BranchID))
                .ForMember(vm => vm.Name, map => map.MapFrom(m => m.BranchName))
                .ForMember(vm => vm.Active, map => map.MapFrom(m => m.Active))
                .ForMember(vm => vm.Deleted, map => map.MapFrom(m => m.Deleted));
            #endregion
        }
    }
}
