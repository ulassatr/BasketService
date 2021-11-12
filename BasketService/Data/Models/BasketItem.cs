using System;

namespace BasketService.Data.Models
{
    public class BasketItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
    }
}