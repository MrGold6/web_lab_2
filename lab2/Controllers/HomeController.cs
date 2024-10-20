using lab1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LR2.Services;

namespace lab1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IEmailSender _emailSender;


        public HomeController(ILogger<HomeController> logger,
            IEmailSender emailSender)
        {
            _logger = logger;
            _emailSender = emailSender;
        }


        [HttpPost]
        public async Task<IActionResult> SendEmail(string name, string email, string subject, string message)
        {
            if (ModelState.IsValid)
            {
                await _emailSender.SendEmailAsync(name, email, subject, message);
            }

            return View("Contact");
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }
        
        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult GallerySingle()
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
    }
}
