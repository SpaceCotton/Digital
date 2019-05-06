using Microsoft.AspNetCore.Antiforgery;
using Bug.Controllers;

namespace Bug.Web.Host.Controllers
{
    public class AntiForgeryController : BugControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
