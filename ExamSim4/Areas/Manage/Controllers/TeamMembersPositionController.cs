using ExamSim4.Areas.Manage.ViewModel.TeamMembersPosition;
using ExamSim4.DAL.Context;
using ExamSim4.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamSim4.Areas.Manage.Controllers
{
    [Area("Manage")]
	public class TeamMembersPositionController : Controller
	{
		AppDbContext _context;

		public TeamMembersPositionController(AppDbContext context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult Index()
		{
			List<TeamMembersPosition> Teammemberspositions = _context.TeamMembersPositions.ToList();
			return View(Teammemberspositions);
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]

		public IActionResult Create(CreateTeamMembersPositionvm vm)
		{
			if (vm == null) 
			{ return View(); }

			TeamMembersPosition position = new TeamMembersPosition()
			{
				Name = vm.Name,
			};
			_context.TeamMembersPositions.Add(position);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));

		}

		public IActionResult Delete(int id)
		{
			if (id <= 0)
			{
				return View();
			}
			var position = _context.TeamMembersPositions.FirstOrDefault(x => x.Id == id);
			if (position == null)
			{
				return View();
			}
			_context.TeamMembersPositions.Remove(position);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));

		}

		public IActionResult Update(int id)
		{
			if (id <= 0)
			{
				return View();
			}
			var position = _context.TeamMembersPositions.FirstOrDefault(x => x.Id == id);
			if (position == null)
			{
				return View();
			}
			UpdateTeamMembersPositionvm vm = new UpdateTeamMembersPositionvm()
			{
             Id = id,
			 Name = position.Name,
			};
			return View(vm);
		}

		[HttpPost]	
		public IActionResult Update(UpdateTeamMembersPositionvm vm)
		{
			if (vm.Id <= 0)
			{
				return View();
			}
			var position = _context.TeamMembersPositions.FirstOrDefault(x => x.Id == vm.Id);
			if (position == null)
			{
				return View();
			}
			TeamMembersPosition oldposition = _context.TeamMembersPositions.FirstOrDefault(y => y.Id == vm.Id);
			if (oldposition == null) 
			{ 
			
			return View (vm);
			}
			oldposition.Id = vm.Id;
			oldposition.Name = vm.Name;
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
			
		}
	}
}
