using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BasketService.Application.Commands.AddItemToBasket;
using BasketService.Dtos;
using BasketService.Infrastructure;
using BasketService.Repository;
using BasketService.Test.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace BasketService.Test.Command
{
    public class AddItemToBasketCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBasketRepository> _mockRepo;
        private readonly BasketItemDto _basketItemDto;

        public AddItemToBasketCommandHandlerTest()
        {
            _mockRepo = MockBasketRepository.GetBasketRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ModelMappers>();
            });

            _mapper = mapperConfig.CreateMapper();

            _basketItemDto = new BasketItemDto()
            {
                Price = 25,
                ProductId = "asd1245",
                ProductName = "ayakkabı",
                Quantity = 2
            };
        }

        [Fact]
        public async Task AddItemToBasket()
        {
            var handler = new AddItemToBasketCommandHandler(_mockRepo.Object, _mapper);
            
            var result = await handler.Handle(new AddItemToBasketCommand()
            {
                BasketId = "first_Basket",
                Item = _basketItemDto
            },CancellationToken.None);

            var basket = await _mockRepo.Object.GetBasket("first_Basket");
            
            result.ShouldBeOfType<BasketDto>();
            
            basket.Items.Count.ShouldBe(4);
        }
    }
}