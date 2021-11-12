using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BasketService.Application.Configuration.Queries;
using BasketService.Dtos;
using BasketService.Repository;
using MediatR;

namespace BasketService.Application.Queries.GetBasket
{
    public class GetBasketQueryHandler : IQueryHandler<GetBasketQuery,BasketDto>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public GetBasketQueryHandler(IBasketRepository basketRepository,IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }
        public async Task<BasketDto> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetBasket(request.BasketId);

            var model = _mapper.Map<BasketDto>(basket);

            return model;
        }
    }
}