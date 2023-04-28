using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace WebshopAPI.Controllers
{
    [ApiController]
    [Authorize("User")]
    public abstract class BaseController : Controller
    {
        protected string _CurrentUser = "System";
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _CurrentUser = this.HttpContext.User.Claims.Single(a => a.Type == ClaimTypes.Email).Value;
            base.OnActionExecuting(context);
        }
    }
}
