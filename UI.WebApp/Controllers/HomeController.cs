using Business.Services;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using System.Web.Mvc;

namespace UI.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITodoService service = ServiceFactory.CreateTodoService();
        // GET: Home
        public ActionResult Index(int? id = null)
        {
            return View(service.GetTodos(id));
        }

        public ActionResult CreateTodo()
        {
            ViewData["Categories"] = new SelectList(service.GetCategories(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTodo(TodoCreateDto todoCreateDto)
        {
            ViewData["Categories"] = new SelectList(service.GetCategories(), "Id", "Name", todoCreateDto.CategoryId);
            if (ModelState.IsValid)
            {
                service.CreateTodo(todoCreateDto);
                return RedirectToAction("Index");
            }
            return View(todoCreateDto);
        }

        public ActionResult CreateCategory() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory(CategoryCreateDto categoryCreateDto)
        {
            if (ModelState.IsValid)
            {
                service.CreateCategory(categoryCreateDto);
                return RedirectToAction("Index");
            }
            return View(categoryCreateDto);
        }
    }
}