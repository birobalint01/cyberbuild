using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebshopAPI.Lib;
using WebshopCommon.Models;

namespace WebshopAPI.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        OrderManagerService orderManagerService;

        public OrderController(OrderManagerService orderManagerService)
        {
            this.orderManagerService = orderManagerService;
        }

        [HttpGet("GetMyOrders")]
        [Authorize("User")]
        public async Task<IActionResult> GetMyOrders()
        {
            APIResponse response = new APIResponse();
            try
            {
                using (SQL sql = new SQL())
                {
                    var orders = sql.Orders.Where(a => a.UserEmail == _CurrentUser).OrderBy(a => a.OrderDate).ToList();
                    orders.ForEach(order =>
                    {
                        order.Products = sql.OrderedProducts.Where(a => a.OrderID == order.ID).ToList();
                    });

                    response.Data = orders;
                }

                return Ok(response);

            }
            catch (Exception e)
            {
                response.StatusCode = 302;
                response.Message = e.Message;
            }

            return BadRequest(response);
        }

        [HttpPost("Order")]
        [Authorize("User")]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            APIResponse response = new APIResponse();

            try
            {
                await orderManagerService.AddOrder(order, _CurrentUser);
                await $"Sikeres vásárlás:\r\n{order.Dump()}".WriteLogAsync(this._CurrentUser);
                return Ok(response);
            }
            catch (InvalidPropertyValueException e)
            {
                response.StatusCode = 303;
                response.Message = e.Message;
            }
            catch (MandatoryPropertyEmptyException e)
            {
                response.StatusCode = 304;
                response.Message = e.Message;
            }
            catch (ProductNotFoundException)
            {
                response.StatusCode = 305;
                response.Message = "A termék nem található!";
            }
            catch (Exception e)
            {
                response.StatusCode = 306;
                response.Message = e.Message;
            }
            await $"Sikertelen vásárlás:\r\n{order.Dump()},\r\nException: {response.Dump()}".WriteErrorAsync(this._CurrentUser);
            return BadRequest(response);
        }

        

    }
}
