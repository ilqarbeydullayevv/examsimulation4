
using ExamSim4.DAL.Context;
using ExamSim4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Diagnostics;

namespace ExamSim4.Controllers
{
    public class HomeController : Controller
    { 
        AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<TeamMembers> members = _context.TeamMembers.Include(x=>x.position).ToList();
            return View(members);
        }

    }
}
