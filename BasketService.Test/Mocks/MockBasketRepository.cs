using System.Collections.Generic;
using BasketService.Data.Models;
using BasketService.Repository;
using Moq;

namespace BasketService.Test.Mocks
{
    public static class MockBasketRepository
    {
        public static Mock<IBasketRepository> GetBasketRepository()
        {
            var basket = new Basket()
            {
                Id = "first_Basket",
                Items = new List<BasketItem>()
                {
                    new()
                    {
                        Id = "item1",
                        Price = 10,
                        ProductId = "uk124",
                        ProductName = "kazak",
                        Quantity = 1
                    },
                    new ()
                    {
                        Id = "item2",
                        Price = 20,
                        ProductId = "us125",
                        ProductName = "pantolon",
                        Quantity = 2
                    }
                }
            };

            var mockRepo = new Mock<IBasketRepository>();
            mockRepo.Setup(x => x.GetBasket(It.IsAny<string>())).ReturnsAsync(basket);

            mockRepo.Setup(x => x.AddItem(It.IsAny<Basket>()))
                .ReturnsAsync((Basket item) =>
                {
                    basket.Items.Add(new BasketItem()
                        { Id = "test", Price = 10, ProductId = "10", ProductName = "T-shirt", Quantity = 10 });
                    return item;
                });

            return mockRepo;
        }
    }
}