using BasketService.Application.Configuration.Queries;
using BasketService.Dtos;

namespace BasketService.Application.Queries.GetBasket
{
    public class GetBasketQuery : IQuery<BasketDto>
    {
        public string BasketId { get; set; }
    }
}