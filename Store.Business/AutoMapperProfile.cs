using AutoMapper;
using Store.DataAccessor.Entities;
using Store.Contracts.Dtos;
using System;

namespace Store.Business
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            FromDataAccessorLayer();
            FromPresentationLayer();
        }

        private void FromPresentationLayer()
        {
            CreateMap<UserDto, User>()
                .ForMember(dest=>dest.Id,o=>o.MapFrom(src=>src.Id))
                .ForMember(dest => dest.UserName, o => o.MapFrom(src => src.UserName))
                .ForMember(dest => dest.LastName, o => o.MapFrom(src => src.LastName))
                .ForMember(dest => dest.FirstName, o => o.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.DateOfBirth, o => o.MapFrom(src => src.DateOfBirth));
            CreateMap<CommentsDto, Comments>();
            CreateMap<AddCommentDto, Comments>();

            CreateMap<ProductDto, Product>();
            CreateMap<TypeDto, DataAccessor.Entities.Type>();
            CreateMap<PicturesDto, Pictures>();



        }

        private void FromDataAccessorLayer()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Id, o => o.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, o => o.MapFrom(src => src.UserName))
                .ForMember(dest => dest.LastName, o => o.MapFrom(src => src.LastName))
                .ForMember(dest => dest.FirstName, o => o.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.DateOfBirth, o => o.MapFrom(src => src.DateOfBirth));
            CreateMap<Comments, CommentsDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<DataAccessor.Entities.Type, TypeDto>();
            CreateMap<Pictures, PicturesDto>();

        }
    }
}
