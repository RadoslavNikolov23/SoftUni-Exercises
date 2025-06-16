namespace Horizons.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    [Authorize]
    public abstract class BaseController : Controller
    {
        protected bool IsAuthenticated()
        {
            bool isAuthenticated = false;

            if (this.User != null && this.User.Identity != null)
            {
                isAuthenticated = User.Identity.IsAuthenticated;
            }

            return isAuthenticated;
        }

        protected string? GetUserId()
        {
            string? userId = null;

            if (this.IsAuthenticated())
            {
                userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            return userId;
        }
    }
}
