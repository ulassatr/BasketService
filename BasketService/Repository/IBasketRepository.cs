using System.Threading.Tasks;
using BasketService.Data.Models;

namespace BasketService.Repository
{
    public interface IBasketRepository
    {
        Task<Basket> GetBasket(string basketId);
        Task<Basket> CreateBasket(Basket basket);
        Task<Basket> AddItem(Basket basket);
    }
}