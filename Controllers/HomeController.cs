using Microsoft.AspNetCore.Mvc;

namespace PlaylistApi.Backend.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect(Url.Content("~/swagger"));
        }
    }
}