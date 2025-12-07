using Business;
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

        public ActionResult DeleteTodo(int id)
        {
            var todo = service.GetTodoById(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }


        [HttpPost]
        public ActionResult DeleteTodoConfirmed(int id)
        {
            service.DeleteTodo(id);
            return RedirectToAction("Index");
        }

        public ActionResult EditTodo(int id)
        {
            var todo = service.GetTodoById(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            var updated = AutoMapperConfig.Mapper.Map<TodoCreateDto>(todo);
            ViewData["Categories"] = new SelectList(service.GetCategories(), "Id", "Name", updated.CategoryId);
            return View(updated);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTodo(int id, TodoCreateDto todoUpdateDto)
        {
            ViewData["Categories"] = new SelectList(service.GetCategories(), "Id", "Name", todoUpdateDto.CategoryId);
            if (ModelState.IsValid)
            {
                service.UpdateTodo(id, todoUpdateDto);
                return RedirectToAction("Index");
            }
            return View(todoUpdateDto);
        }
    }
}