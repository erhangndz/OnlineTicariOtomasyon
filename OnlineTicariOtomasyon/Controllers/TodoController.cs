using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public IActionResult Index()
        {
            using var c = new Context();
            ViewBag.d1 = c.Currents.Count();
            ViewBag.d2 = c.Products.Count();
            ViewBag.d3 = c.Categories.Count();
            ViewBag.d4 = c.Staffs.Count();

            var values= _todoService.TGetList();
            return View(values);
        }
    }
}
