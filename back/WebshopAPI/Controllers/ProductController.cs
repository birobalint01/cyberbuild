using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebshopAPI.Lib;
using WebshopAPI.Lib.Services;
using WebshopCommon.Models;

namespace WebshopAPI.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> ListProducts()
        {
            APIResponse response = new APIResponse();
            try
            {
                using (SQL sql = new SQL())
                {
                    var products = sql.Products.Where(a => a.Stock > 0).OrderBy(a => a.Name).ToList();

                    response.Data = products;
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                response.StatusCode = 201;
                response.Message = e.Message;
            }
            return BadRequest(response);
        }

        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct(string name)
        {
            APIResponse response = new APIResponse();
            try
            {
                using (SQL sql = new SQL())
                {
                    if (sql.Products.Any(a => a.Name == name))
                    {
                        Product product = sql.Products.Single(a => a.Name == name);
                        response.Data = product;
                        return Ok(response);
                    }
                    else
                    {
                        throw new ProductNotFoundException();
                    }
                }
            }
            catch (ProductNotFoundException)
            {
                response.StatusCode = 202;
                response.Message = $"A megadott nevű termék nem létezik! Termék neve: {name}!";
            }
            catch (Exception e)
            {
                response.StatusCode = 203;
                response.Message = e.Message;
            }
            await $"A termék lekérése sikertelen:\r\nTermék: {name}".WriteLogAsync();
            return BadRequest(response);
        }

        [HttpGet("SearchProduct")]
        public async Task<IActionResult> SearchProduct(string searchstring)
        {
            APIResponse response = new APIResponse();
            try
            {
                using (SQL sql = new SQL())
                {
                    IEnumerable<Product> products = sql.Products.Where(a => a.Name.Contains(searchstring) || a.Description.Contains(searchstring)).Select(a => new Product()
                    {
                        Name = a.Name,
                        Description = a.Description,
                        Price = a.Price,
                        Stock = a.Stock
                    }).ToList();
                    response.Data = products;
                    return Ok(response);
                }
            }
            catch (Exception e)
            {
                response.StatusCode = 204;
                response.Message = e.Message;
            }
            await $"A termék keresése sikertelen:\r\nSearchstring: {searchstring}".WriteLogAsync();
            return BadRequest(response);
        }
    }
}
