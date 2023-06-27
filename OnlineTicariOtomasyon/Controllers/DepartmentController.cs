using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IStaffService _staffService;
        private readonly ITransactionService _transactionService;

        public DepartmentController(IDepartmentService departmentService, IStaffService staffService, ITransactionService transactionService)
        {
            _departmentService = departmentService;
            _staffService = staffService;
            _transactionService = transactionService;
        }

        public IActionResult Index()
        {
            var values = _departmentService.TGetList().OrderByDescending(x=>x.Status).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDepartment(Department p)
        {
            p.Status = true;
            _departmentService.TInsert(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateDepartment(int id)
        {
            var values = _departmentService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateDepartment(Department p)
        {
            p.Status=true;
            _departmentService.TUpdate(p);
            return RedirectToAction("Index");
        }

        public IActionResult DepartmentDetails(int id)
        {
            var values= _staffService.TGetListwithDepartment().Where(x=>x.DepartmentID==id).ToList();
            var department= _departmentService.TGetList().Where(x=>x.DepartmentID==id).Select(x=>x.DepartmentName).FirstOrDefault();
            ViewBag.dpt = department;
            return View(values);
        }

        public IActionResult DeleteDepartment(int id)
        {
            var values = _departmentService.TGetByID(id);
            if (values.Status == true)
            {
                values.Status = false;
                _departmentService.TUpdate(values);
            }
            else
            {
                values.Status = true;
                _departmentService.TUpdate(values);
            }


            return RedirectToAction("Index");
        }

        public IActionResult SaleDetails(int id)
        {
            var values= _transactionService.TGetAll().Where(x=>x.StaffID==id).ToList();
            var staff = _staffService.TGetList().Where(x => x.StaffID == id).Select(x => x.Name + " " + x.Surname).FirstOrDefault();
            ViewBag.staff = staff;
            return View(values);
        }
    }
}
