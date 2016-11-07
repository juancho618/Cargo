using AutoMapper;
using Cargo.Data.Entities;
using Cargo.Domain.ViewModels.Parametrizacion;

namespace Cargo.Data.Mappings
{
    public class MapperConfigurationFromViewModel : Profile
    {
        protected override void Configure()
        {
            #region Parametrization
            CreateMap<UnitTypeViewModel, UnitType>();
            CreateMap<CountryViewModel, Country>();
            #endregion
        }
    }
}
