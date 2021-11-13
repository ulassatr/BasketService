using System;
using System.Collections.Generic;

namespace BasketService.Data.Models
{
    public class Basket
    {
        public string Id { get; set; }
        public List<BasketItem> Items { get; set; } = new();
        
        public decimal TotalPrice
        {
            get
            {
                decimal totalprice = 0;
                foreach (var item in Items)
                {
                    totalprice += item.Price * item.Quantity;
                }

                return totalprice;
            }
        }

        public Basket(string id)
        {
            Id = id;
        }

        public Basket()
        {
        }
    }
}