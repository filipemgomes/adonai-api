using Microsoft.AspNetCore.Mvc;

namespace AdonaiApi.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public string GetVersion() => "1.0.0v";
    }
}