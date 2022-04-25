using AutoMapper;

namespace Pattern.Exam.Services.Configurations
{
    internal class MapperConfigurations : Profile
    {
        public MapperConfigurations()
        {
            CreateMap<Infrastructure.Entities.Basket, Domain.Basket>().ReverseMap();
            CreateMap<Infrastructure.Entities.Product, Domain.Product>();
        }
    }
}
