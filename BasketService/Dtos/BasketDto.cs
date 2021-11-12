using System.Collections.Generic;

namespace BasketService.Dtos
{
    public class BasketDto
    {
        public string Id { get; set; }
        public List<BasketItemDto> Items { get; set; }
        public decimal TotalPrice { get; set; }
        
    }
}