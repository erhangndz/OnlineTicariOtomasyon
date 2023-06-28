using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _productService.TGetListwithCategories().OrderByDescending(x=>x.Status).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            List<SelectListItem> category = (from x in _categoryService.TGetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.category = category;
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            List<SelectListItem> category = (from x in _categoryService.TGetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.category= category;
            p.Status = true;
            _productService.TInsert(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            List<SelectListItem> category = (from x in _categoryService.TGetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.category = category;
            var values = _productService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product p)
        {
            List<SelectListItem> category = (from x in _categoryService.TGetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.category = category;
            p.Status = true;
            _productService.TUpdate(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            var values = _productService.TGetByID(id);
            if (values.Status == true)
            {
                values.Status = false;
                _productService.TUpdate(values);
            }
            else
            {
                values.Status = true;
                _productService.TUpdate(values);
            }
           
            
            return RedirectToAction("Index");
        }

        public IActionResult ProductList()
        {
           var values= _productService.TGetListwithCategories();
            return View(values);
        }

        public IActionResult ProductDetails(int id)
        {
            var values = _productService.TGetByID(id);
            return View(values);
        }


    }
}
