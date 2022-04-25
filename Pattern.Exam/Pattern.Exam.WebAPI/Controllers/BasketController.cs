using Microsoft.AspNetCore.Mvc;
using Pattern.Exam.Services.Interfaces;
using Pattern.Exam.WebAPI.Requests;

namespace Pattern.Exam.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketFacade _basketFacade;

        public BasketController(IBasketFacade basketFacade)
        {
            _basketFacade = basketFacade;
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> Get([FromRoute] Guid accountId)
        {
            var basket = await _basketFacade.GetAsync(accountId);
            if (basket == null)
                return NotFound();

            return Ok(basket);
        }

        [HttpPut()]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequest addProductRequest)
        {
            try
            {
                await _basketFacade.AddAsync(addProductRequest.AccountId, addProductRequest.ProductId);
                return Ok();
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpDelete("{accountId")]
        public async Task<IActionResult> RemoveProduct([FromRoute] Guid accountId, [FromQuery] Guid productId)
        {
            try
            {
                await _basketFacade.RemoveAsync(accountId, productId);
                return Ok();
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
