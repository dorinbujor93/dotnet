using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BikeStore___Project.Domain.Enums;
using BikeStore___Project.Domain.Models;
using BikeStore___Project.Extensions;
using BikeStore___Project.Resources;

namespace BikeStore___Project.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveBikeResource, Bike>();
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveOrderResource, Order>();
            CreateMap<SaveShopResource, Shop>();

            CreateMap<BikeResource, Bike>()
                .ForMember(src => src.FrameType,
                    opt => opt.MapFrom(src => (EFrameType) src.FrameType));
            CreateMap<Bike, BikeResource>()
                .ForMember(src => src.FrameSize,
                    opt => opt.MapFrom(src => (EFrameSize) src.FrameSize));
            CreateMap<Accessory, AccessoryResource>()
                .ForMember(src => src.AccessoryType,
                    opt => opt.MapFrom(src => (EAccessoryType) src.AccessoryType));
            CreateMap<User, UserResource>()
                .ForMember(src => src.Gender,
                    opt => opt.MapFrom(src => (EGender) src.Gender));
        }
    }
}