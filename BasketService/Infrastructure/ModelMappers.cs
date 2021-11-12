using AutoMapper;
using BasketService.Data.Models;
using BasketService.Dtos;

namespace BasketService.Infrastructure
{
    public class ModelMappers : Profile
    {
        public ModelMappers()
        {
            CreateMap<Basket, BasketDto>();
            CreateMap<BasketItem, BasketItemDto>();
            CreateMap<BasketDto, Basket>();
            CreateMap<BasketItemDto, BasketItem>();
        }
    }
}