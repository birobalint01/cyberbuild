using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebshopAPI.Lib.Services;
using WebshopAPI.Lib;

namespace WebshopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Operator")]
    public class OperatorController : BaseController
    {
        ProductManagerService productManagerService;
        OrderManagerService orderManagerService;

        public OperatorController(ProductManagerService productManagerService, OrderManagerService orderManagerService)
        {
            this.productManagerService = productManagerService;
            this.orderManagerService = orderManagerService;
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            APIResponse response = new APIResponse();
            try
            {
                ObjectValidatorService<Product> productValid = new ObjectValidatorService<Product>(product);
                productValid.IsValid();
                await this.productManagerService.AddProduct(product);
                await $"Sikeres termék felvétel:\r\n{product.Dump()}".WriteLogAsync(this._CurrentUser);
                return Ok(response);
            }
            catch (InvalidPropertyValueException e)
            {
                response.StatusCode = 205;
                response.Message = e.Message;
            }
            catch (MandatoryPropertyEmptyException e)
            {
                response.StatusCode = 206;
                response.Message = e.Message;
            }
            catch (Exception e)
            {
                response.StatusCode = 207;
                response.Message = e.Message;
            }
            await $"Sikertelen termék felvétel:\r\n{product.Dump()},\r\nException: {response.Dump()}".WriteErrorAsync(this._CurrentUser);
            return BadRequest(response);
        }

        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            APIResponse response = new APIResponse();
            try
            {
                await productManagerService.UpdateProduct(product);
                await $"Sikeres termék frissítés:\r\n{product.Dump()}".WriteLogAsync(this._CurrentUser);
                return Accepted(response);

            }
            catch (InvalidPropertyValueException e)
            {
                response.StatusCode = 208;
                response.Message = e.Message;
            }
            catch (MandatoryPropertyEmptyException e)
            {
                response.StatusCode = 209;
                response.Message = e.Message;
            }
            catch (ProductNotFoundException)
            {
                response.StatusCode = 210;
                response.Message = $"A termék nem található! Termék: {product.Name}";
            }
            catch (Exception e)
            {
                response.StatusCode = 211;
                response.Message = e.Message;
            }
            await $"Sikertelen termék frissítés:\r\n{product.Dump()},\r\nException: {response.Dump()}".WriteErrorAsync(this._CurrentUser);
            return BadRequest(response);
        }

        [HttpPost("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder([FromBody] Order order)
        {
            APIResponse response = new APIResponse();

            try
            {
                await orderManagerService.UpdateOrder(order);
                await $"Sikeres rendelés frissítés:\r\n{order.Dump()}".WriteLogAsync(this._CurrentUser);
                return Ok(response);
            }
            catch (InvalidPropertyValueException e)
            {
                response.StatusCode = 307;
                response.Message = e.Message;
            }
            catch (MandatoryPropertyEmptyException e)
            {
                response.StatusCode = 308;
                response.Message = e.Message;
            }
            catch (OrderNotFoundException)
            {
                response.StatusCode = 309;
                response.Message = "A rendelés nem található!";
            }
            catch (Exception e)
            {
                response.StatusCode = 310;
                response.Message = e.Message;
            }
            await $"Sikertelen vásárlás frissítés:\r\n{order.Dump()},\r\nException: {response.Dump()}".WriteErrorAsync(this._CurrentUser);
            return BadRequest(response);
        }

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            APIResponse response = new APIResponse();

            try
            {
                using (SQL sql = new SQL())
                {
                    var orders = sql.Orders.OrderBy(a => a.OrderDate).ToList();
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
                response.StatusCode = 301;
                response.Message = e.Message;
            }
            return BadRequest(response);
        }
    }
}
