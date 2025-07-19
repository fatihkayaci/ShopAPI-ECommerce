using AutoMapper;
using ShopAPI.Application.DTOs;
using ShopAPI.Domain.Entities;

namespace ShopAPI.Application.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // Product Entity → ProductResponseDto
            CreateMap<Product, ProductResponseDto>();

            // CreateProductDto → Product Entity  
            CreateMap<CreateProductDto, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // ID ignore et
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            // UpdateProductDto → Product Entity
            CreateMap<UpdateProductDto, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // ID ignore et
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()) // CreatedAt değişmesin
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}