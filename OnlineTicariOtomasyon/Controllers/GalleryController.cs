using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IProductService _productService;

        public GalleryController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var values= _productService.TGetList();
            return View(values);
        }
    }
}
