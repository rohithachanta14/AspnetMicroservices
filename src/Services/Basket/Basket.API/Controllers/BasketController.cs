using Basket.API.Entities;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository_ctx;
        private readonly ILogger<BasketController> _logger;

        public BasketController(IBasketRepository basketRepository_ctx, ILogger<BasketController> logger)
        {
            _basketRepository_ctx = basketRepository_ctx ?? throw new ArgumentNullException(nameof(basketRepository_ctx));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("{username}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string username)
        {
            var items = await _basketRepository_ctx.GetBasket(username);
            return Ok(items ?? new ShoppingCart(username));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket(ShoppingCart basket)
        {
            return Ok(await _basketRepository_ctx.UpdateBasket(basket));
        }


        [HttpDelete("{username}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string username)
        {
            await _basketRepository_ctx.DeleteBasket(username);
            return Ok();
        }
    }
}