using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using WebAppTask.Models;

namespace WebAppTask.Controllers
{
    public class TaskController : Controller
    {
        static List<Tasks> tasks = new List<Tasks>() {
        new Tasks() {Id = 1,Title="Task1",Description="1st Task",DueDate=new DateTime(year:2024,month:1,day:23)},
        };
        public IActionResult Index()
        {
            return View(tasks);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Tasks t)
        {
            if(ModelState.IsValid)
            {
                tasks.Add(t);

                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Tasks t=tasks.SingleOrDefault(x => x.Id == id);
            return View(t);
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            Tasks t = tasks.SingleOrDefault(x => x.Id == id);
            if (t != null)
            {
                tasks.Remove(t);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Tasks t = tasks.SingleOrDefault(x => x.Id == id);
            return View(t);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Tasks t = tasks.SingleOrDefault(x => x.Id == id);
            return View(t);
        }

        [HttpPost]
         public IActionResult Edit(int? id,string Title,string Description, DateTime DueDate)
        {
            Tasks t = tasks.SingleOrDefault(x => x.Id == id);
             if(t != null)
            {
           
                t.Title = Title;
                t.Description = Description;
                t.DueDate = DueDate;
            }
               
      
           
            return RedirectToAction("Index");
        }
    }
}
