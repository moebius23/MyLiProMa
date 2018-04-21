using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyLittleProjectManager.Data;
using MyLittleProjectManager.Models;

namespace MyLittleProjectManager.Controllers
{
    public class ProjectController : Controller
    {
		ApplicationDbContext context = new ApplicationDbContext(null);

        public IActionResult Index()
        {
			Project project = context.Projects.FirstOrDefault();
            return View(project);
        }

        public JsonResult MoveCard(int CardId, int NewColumnId)
        {
            Console.WriteLine(String.Format("Moving card {0} to column {1}",CardId,NewColumnId));
            return Json(CardId);
        }
        public JsonResult DeleteCard(int CardId)
        {
            Console.WriteLine(String.Format("Deleting card {0}", CardId));
            return Json(CardId);
        }


        public List<Column> Columns(int projectId)
        {
			return context.Columns.Where(p => p.Id == projectId).ToList();
        }
    }
}