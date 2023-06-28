using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class BillController : Controller
    {
        private readonly IBillService _billService;
        private readonly IBillItemService _billItemService;

        public BillController(IBillService billService, IBillItemService billItemService)
        {
            _billService = billService;
            _billItemService = billItemService;
        }

        public IActionResult Index()
        {
            var values = _billService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddBill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBill(Bill p)
        {
            _billService.TInsert(p);
            return RedirectToAction("Index");
        }

        public IActionResult BillDetails(int id)
        {
            var values = _billItemService.TGetList().Where(x => x.BillID == id).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult UpdateBill(int id)
        {
            var values = _billService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateBill(Bill p)
        {
            _billService.TUpdate(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddBillItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBillItem(BillItem p)
        {
            _billItemService.TInsert(p);
            return RedirectToAction("Index");
        }
    }
}
