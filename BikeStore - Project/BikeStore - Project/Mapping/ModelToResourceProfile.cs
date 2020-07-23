using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BikeStore___Project.Domain.Models;
using BikeStore___Project.Extensions;
using BikeStore___Project.Resources;

namespace BikeStore___Project.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Shop, ShopResource>();
            CreateMap<Order, OrderResource>();
            CreateMap<Bike, SaveBikeResource>();
            CreateMap<User, SaveUserResource>();
            CreateMap<Order, SaveOrderResource>();
            CreateMap<Bike, BikeResource>()
                .ForMember(src => src.FrameType,
                    opt => opt.MapFrom(src => src.FrameType.ToDescriptionString()));
            CreateMap<Bike, BikeResource>()
                .ForMember(src => src.FrameSize,
                    opt => opt.MapFrom(src => src.FrameSize.ToDescriptionString()));
            CreateMap<Accessory, AccessoryResource>()
                .ForMember(src => src.AccessoryType,
                    opt => opt.MapFrom(src => src.AccessoryType.ToDescriptionString()));
            CreateMap<User, UserResource>()
                .ForMember(src => src.Gender,
                    opt => opt.MapFrom(src => src.Gender.ToDescriptionString()));
        }
    }
}