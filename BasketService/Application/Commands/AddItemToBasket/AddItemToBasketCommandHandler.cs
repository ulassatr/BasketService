using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BasketService.Application.Configuration.Commands;
using BasketService.Data.Models;
using BasketService.Dtos;
using BasketService.Repository;
using MediatR;

namespace BasketService.Application.Commands.AddItemToBasket
{
    public class AddItemToBasketCommandHandler : ICommandHandler<AddItemToBasketCommand, BasketDto>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public AddItemToBasketCommandHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<BasketDto> Handle(AddItemToBasketCommand command, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetBasket(command.BasketId);
            var item = _mapper.Map<BasketItem>(command.Item);

            basket ??= await _basketRepository.CreateBasket(new Basket(command.BasketId));

            basket.Items.Add(item);
            var itemAddedBasket = await _basketRepository.AddItem(basket);

            var model = _mapper.Map<BasketDto>(itemAddedBasket);
            return model;
        }
    }
}