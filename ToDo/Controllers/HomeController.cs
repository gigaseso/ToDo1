using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Todo> myList = new List<Todo>();

            myList.Add(new Todo() { TaskId = 1, Name = "Make ToDo List App", Description = "You need to make application. You Should use MVC design pattern." });
            myList.Add(new Todo() { TaskId = 2, Name = "Watch Movie", Description = "Download new movies..." });
            myList.Add(new Todo() { TaskId = 3, Name = "Read Book", Description = "Buy new book." });
            myList.Add(new Todo() { TaskId = 4, Name = "Listen To Music", Description = "Buy new Album on Itunes." });




            return View(myList);
        }

        public ActionResult Details(int Id)
        {


            List<Todo> myList = new List<Todo>();

            myList.Add(new Todo() { TaskId = 1,Name = "Make ToDo List App", Description = "You need to make application. You Should use MVC design pattern." , Priority = 1, DueDate = new DateTime(2016/12/8) });
            myList.Add(new Todo() { TaskId = 2, Name = "Watch Movie", Description = "Download new movies...", Priority = 1, DueDate = new DateTime(2016 / 12 / 29) });
            myList.Add(new Todo() { TaskId=3, Name = "Read Book", Description = "Buy new book.", Priority = 1, DueDate = new DateTime(2016 / 12 / 31) });
            myList.Add(new Todo() { TaskId=4,  Name = "Listen To Music", Description = "Buy new Album on Itunes.", Priority = 1, DueDate = new DateTime(2016 / 12 / 31) });

            return View(myList.Where(x => x.TaskId == Id).FirstOrDefault());

        }

        public ActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTask(Todo td)
        {
            

            MyDataBaseDataContext db = new MyDataBaseDataContext();
            db.ToDos.InsertOnSubmit(new Models.ToDo() {
                Name = td.Name,
                Description = td.Description,
                Type = td.Type,
                Priority = td.Priority,
                DueDate = td.DueDate
            });
            db.SubmitChanges();

            return View();
        }


    }
}