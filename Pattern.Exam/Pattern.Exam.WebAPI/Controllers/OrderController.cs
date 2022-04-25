using Microsoft.AspNetCore.Mvc;
using Pattern.Exam.Services.Interfaces;
using Pattern.Exam.WebAPI.Requests;

namespace Pattern.Exam.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderFacade _orderFacade;

        public OrderController(IOrderFacade orderFacade)
        {
            _orderFacade = orderFacade;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest createOrderRequest)
        {
            try
            {
                var order = await _orderFacade.CreateAsync(createOrderRequest.AccountId);
                return Ok(order);
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }           

        }
    }
}
