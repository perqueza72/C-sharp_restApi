using AutoMapper;

namespace ProductProject.API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Entities.Product, Models.ProductModel.Product>();
            CreateMap<Models.ProductModel.Product, Entities.Product>();
        }
    }
}
