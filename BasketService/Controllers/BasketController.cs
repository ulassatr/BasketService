using System.Net;
using System.Threading.Tasks;
using BasketService.Application.Commands.AddItemToBasket;
using BasketService.Application.Queries.GetBasket;
using BasketService.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BasketService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;
        private readonly IMediator _mediator;

        public BasketController(ILogger<BasketController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{basketId}")]
        [ProducesResponseType(typeof(BasketDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BasketDto>> GetBasket(string basketId)
        {
            var resp = await _mediator.Send(new GetBasketQuery() { BasketId = basketId });

            return Ok(resp ?? new BasketDto());
        }
        
        [HttpPost("")]
        [ProducesResponseType(typeof(BasketDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BasketDto>> GetBasket([FromBody] AddItemToBasketCommand command)
        {
            var resp = await _mediator.Send(command);

            return Ok(resp ?? new BasketDto());
        }
    }
}