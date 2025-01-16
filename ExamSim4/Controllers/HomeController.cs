
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExamSim4.Controllers
{
    public class HomeController : Controller
    { 


        public IActionResult Index()
        {
            return View();
        }

    }
}
