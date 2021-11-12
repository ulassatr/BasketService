using System;
using AutoMapper;
using BasketService.Application.Configuration.Commands;
using BasketService.Dtos;
using MediatR;

namespace BasketService.Application.Commands.AddItemToBasket
{
    public class AddItemToBasketCommand : ICommand<BasketDto>
    {
        public string BasketId { get; set; }
        public BasketItemDto Item { get; set; }
        public Guid Id { get; }
    }
}