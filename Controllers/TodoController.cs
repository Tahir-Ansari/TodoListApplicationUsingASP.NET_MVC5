using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.Models;
using TodoList.Repos;
using TodoList.ViewModels;

namespace TodoList.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoRepos todoRepos;

        public TodoController()
        {
            todoRepos = new TodoRepos();
        }
        // GET: Todo
        public ActionResult GetTodo()
        {
            var history = todoRepos.GetAllHistory();
            var allTodo = todoRepos.GetAllTodo();

            AllRecords allRecords = new AllRecords
            {
                Histories = history,
                Todos = allTodo
            };

            return View(allRecords);
        }

        public ActionResult AddTodo()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddTodo(Todo todo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    todoRepos.AddTodo(todo);
                    todo.MarkedDone = true;

                }
                ModelState.Clear();
                return RedirectToAction("GetTodo", "Todo");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult UpdateTodoList(int id)
        {
            return View(todoRepos.GetAllTodo().Find(t => t.ID == id));


        }

        [HttpPost]
        public ActionResult UpdateTodoList(int id, Todo todo)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    todoRepos.UpdateTodos(todo);
                }
                ModelState.Clear();
                return RedirectToAction("GetTodo", "Todo");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult DeleteTodo(int id)
        {
            try
            {
                todoRepos.DeleteTodo(id);

                return RedirectToAction("GetTodo");

            }
            catch
            {
                return View();
            }
        }

        public ActionResult ActiveTask()
        {
            return View(todoRepos.GetActiveTodo());
        }

        public ActionResult UpdateTodo(int id)
        {
            todoRepos.UpdateTodo(id);
            return Json(new { result = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TodoHistory()
        {
            return View(todoRepos.GetAllHistory());
        }



    }
}