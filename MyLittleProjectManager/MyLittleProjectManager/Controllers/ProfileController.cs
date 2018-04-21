using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLittleProjectManager.Models;

namespace MyLittleProjectManager.Controllers
{
    public class ProfileController : Controller
    {
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            PlayerProfile pp = new PlayerProfile();
            pp.Pseudo = "Salsify";
            return View(pp);
        }
    }
}