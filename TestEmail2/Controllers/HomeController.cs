using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestEmail2.Models;

namespace TestEmail2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult Index(string to, string subject, string body)
        {
            try
            {
                Thread email = new Thread(delegate ()
                {
                    Sendmail.Email(to, subject, body);
                });
                email.IsBackground = true;
                email.Start();
                TempData["alert"] = "Send Success";
            }
            catch(Exception)
            {
                TempData["alert"] = "Problem Send";
            }
            return Redirect("Home/Index");
        }
    }
}