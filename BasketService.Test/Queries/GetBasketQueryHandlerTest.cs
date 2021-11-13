using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BasketService.Application.Queries.GetBasket;
using BasketService.Dtos;
using BasketService.Infrastructure;
using BasketService.Repository;
using BasketService.Test.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace BasketService.Test.Queries
{
    public class GetBasketQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBasketRepository> _mockRepo;

        public GetBasketQueryHandlerTest()
        {
            _mockRepo = MockBasketRepository.GetBasketRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ModelMappers>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetBasketQueryHandler()
        {
            var handler = new GetBasketQueryHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetBasketQuery(),CancellationToken.None);

            result.ShouldBeOfType<BasketDto>();
            
            result.Items.Count.ShouldBe(2);
        }
    }
}