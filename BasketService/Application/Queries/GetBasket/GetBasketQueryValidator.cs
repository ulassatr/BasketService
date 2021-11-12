using FluentValidation;
using Microsoft.Extensions.Logging;

namespace BasketService.Application.Queries.GetBasket
{
    public class GetBasketQueryValidator : AbstractValidator<GetBasketQuery>
    {
        public GetBasketQueryValidator(ILogger<GetBasketQueryValidator> logger)
        {
            RuleFor(x => x.BasketId).NotEmpty();
            logger.LogError("BasketId is empty");
        }
    }
}