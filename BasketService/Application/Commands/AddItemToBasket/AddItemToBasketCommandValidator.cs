using FluentValidation;
using Microsoft.Extensions.Logging;

namespace BasketService.Application.Commands.AddItemToBasket
{
    public class AddItemToBasketCommandValidator : AbstractValidator<AddItemToBasketCommand>
    {
        public AddItemToBasketCommandValidator(ILogger<AddItemToBasketCommandValidator> logger)
        {
            RuleFor(x => x.BasketId).NotEmpty();
            logger.LogError("BasketId is Empty");
        }
        
    }
}