using ExamSim4.Areas.Manage.ViewModel.TeamMembers;
using ExamSim4.DAL.Context;
using ExamSim4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamSim4.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TeamMembersController : Controller
    {
        AppDbContext _context;

        public TeamMembersController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<TeamMembers> teamMembers = _context.TeamMembers.Include(x => x.position).ToList();
            return View(teamMembers);
        }

        public IActionResult Create()
        {
            ViewBag.TeamMembersPositions = _context.TeamMembersPositions.ToList();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTeamMembersvm vm)
        {
            ViewBag.TeamMembersPositions = _context.TeamMembersPositions.ToList();
              string filename = vm.MyFile.FileName;
              string path = "C:\\Users\\classtime\\Desktop\\ExamSim4\\ExamSim4\\wwwroot\\upload\\Teammember\\";

            if (!vm.MyFile.ContentType.Contains("image"))
            {

                ModelState.AddModelError("File", "duzgun fayl daxil edin");
                return View();
            }
            if (vm.MyFile.Length > 2097152)
            {
                ModelState.AddModelError("File", "Sekil 2 mb dan boyuk ola bilmez");
                return View();
            }

            using (FileStream stream = new FileStream(Path.Combine(path, filename) , FileMode.Create))
              {
                  vm.MyFile.CopyTo(stream);
              }

              
              
            
            if (vm.TeamMembersPositionId != null)
            {

                if (!_context.TeamMembersPositions.Any(c => c.Id == vm.TeamMembersPositionId))
                {
                    ModelState.AddModelError("TeamMembersPositionId ", $"{vm.TeamMembersPositionId}-li position yoxdur ");
                    return View();

                }
            }

            TeamMembers members = new TeamMembers()
            {
                FullName = vm.FullName,
                TeamMembersPositionId = vm.TeamMembersPositionId,
                ImgUrl=vm.MyFile.FileName,
            };



             _context.TeamMembers.Add(members);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
        public IActionResult Delete (int id)
        {
            if (id == null)
            {
                return View();
            }
            var member = _context.TeamMembers.FirstOrDefault(c => c.Id == id);
            if (member == null)
            {
                return View();
            }
            _context.TeamMembers.Remove(member);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update (int id)
        {
            ViewBag.TeamMembersPositions = _context.TeamMembersPositions.ToList();
            if (id == null)
            {
                return View();
            }
            var member = _context.TeamMembers.FirstOrDefault(c => c.Id == id);
            if (member == null)
            {
                return View();
            }
            UpdateTeamMembersvm vm = new UpdateTeamMembersvm()
            {
                Id = id,
                FullName = member.FullName,
                TeamMembersPositionId= member.TeamMembersPositionId,

            };
            return View(vm);

        }
        [HttpPost]
        public IActionResult Update (UpdateTeamMembersvm vm)
        {
            ViewBag.TeamMembersPositions = _context.TeamMembersPositions.ToList();
            if (vm.Id == null)
            {
                return View();
            }
            var member = _context.TeamMembers.FirstOrDefault(c => c.Id == vm.Id);
            if (member == null)
            {
                return View();
            }
            TeamMembers oldmember = _context.TeamMembers.FirstOrDefault(c=> c.Id == vm.Id);
            if (oldmember == null) {
                return View();
            }
            oldmember.Id = vm.Id;
            oldmember.FullName = vm.FullName;
            oldmember.TeamMembersPositionId = vm.TeamMembersPositionId;
           _context.SaveChanges();
            return RedirectToAction(nameof(Index ));


        }
    }
}
