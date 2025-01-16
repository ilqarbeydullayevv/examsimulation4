using ExamSim4.DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace ExamSim4.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DashboardController : Controller
    {
      

        public IActionResult Index()
        {
            return View();
        }
    }
}
