using AutoMapper;

namespace Cargo.Data.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<MapperConfigurationFromModel>();
                x.AddProfile<MapperConfigurationFromViewModel>();
            });
        }
    }
}
