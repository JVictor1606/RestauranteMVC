using AutoMapper;
using Bra.ProductApi.Model;
using Bra.ProductApi.Model.Dto;

namespace Bra.ProductApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });

            return mappingConfig;
        }
    }
}
