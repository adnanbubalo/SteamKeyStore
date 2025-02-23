using AutoMapper;
using SteamKeyStore.Model.Models;

namespace SteamKeyStore.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<string?, string>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<double?, double>().ConvertUsing((src, dest) => src ?? dest);

            CreateMap<Database.User, User>();

            CreateMap<Database.Product, Product>();

            CreateMap<Database.Edition, Edition>();

            CreateMap<Database.Coupon, Coupon>();

            CreateMap<Database.News, News>();

            CreateMap<Database.Order, Order>();

            CreateMap<Database.OrderItem, OrderItem>();

            CreateMap<Database.OrderItemKey, OrderItemKey>();

            CreateMap<Database.ProductKey, ProductKey>();

            CreateMap<Database.Review, Review>();

            CreateMap<Database.Sale, Sale>();

            CreateMap<Database.Tag, Tag>();

            CreateMap<Database.Wishlist, Wishlist>();            
        }
    }
}
