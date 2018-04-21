using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyLittleProjectManager.Models;

namespace MyLittleProjectManager.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            Project project = new Project()
            {
                Id = 1,
                Name = "MyLittleProjectManager",
                Columns = new System.Collections.ObjectModel.ObservableCollection<Column>()
                {
                    new Column()
                    {
                        Id =1,
                        Name ="To Do",
                        Order =0,
                        Cards = new System.Collections.ObjectModel.ObservableCollection<Card>()
                        {
                            new Card()
                            {
                                Id = 0,
                                Order = 0,
                                Name = "Create Data",
                                Description = "All your data are belong to us !"
                            },
                            new Card()
                            {
                                Id = 1,
                                Order = 1,
                                Name = "Process Data",
                                Description = "An army of monkeys is working on the data."
                            }
                        }
                    },
                    new Column(){Id=2,Name="Doing",Order=1},
                    new Column(){Id=3,Name="Done",Order=2}
                }
            };
            return View(project);
        }
    }
}