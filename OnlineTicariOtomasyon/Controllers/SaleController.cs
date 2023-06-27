using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineTicariOtomasyon.Controllers
{
    public class SaleController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IProductService _productService;
        private readonly ICurrentService _currentService;
        private readonly IStaffService _staffService;

        public SaleController(ITransactionService transactionService, IProductService productService, ICurrentService currentService, IStaffService staffService)
        {
            _transactionService = transactionService;
            _productService = productService;
            _currentService = currentService;
            _staffService = staffService;
        }

        public IActionResult Index()
        {
            var values= _transactionService.TGetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult NewSale()
        {
            List<SelectListItem> product= (from x in  _productService.TGetList() select new SelectListItem
            {
                Text=x.ProductName,
                Value=x.ProductID.ToString(),
            }).ToList();
            ViewBag.product= product;

            List<SelectListItem> staff = (from x in _staffService.TGetList()
                                            select new SelectListItem
                                            {
                                                Text = x.Name+ " " + x.Surname,
                                                Value = x.StaffID.ToString(),
                                            }).ToList();
            ViewBag.staff = staff;

            List<SelectListItem> current = (from x in _currentService.TGetList()
                                          select new SelectListItem
                                          {
                                              Text = x.Name + " " + x.Surname,
                                              Value = x.CurrentID.ToString(),
                                          }).ToList();
            ViewBag.current = current;
            return View();
        }

        [HttpPost]
        public IActionResult NewSale(Transaction p)
        {
            p.Date= DateTime.Now;
            _transactionService.TInsert(p);
            return RedirectToAction("Index");
        }
    }
}
