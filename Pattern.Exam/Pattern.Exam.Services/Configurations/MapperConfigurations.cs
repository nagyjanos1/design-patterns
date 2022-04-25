using AutoMapper;
using Pattern.Exam.Domain;

namespace Pattern.Exam.Services.Configurations
{
    internal class MapperConfigurations : Profile
    {
        public MapperConfigurations()
        {
            CreateMap<Infrastructure.Entities.Basket, Basket>().ReverseMap();
            CreateMap<Infrastructure.Entities.Product, Product>();
        }
    }
}
