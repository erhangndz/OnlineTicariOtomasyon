using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineTicariOtomasyon.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;
        private readonly IDepartmentService _departmentService;

        public StaffController(IStaffService staffService, IDepartmentService departmentService)
        {
            _staffService = staffService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var values = _staffService.TGetListwithDepartment().OrderByDescending(x=>x.Status).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddStaff()
        {
            List<SelectListItem> department = (from x in _departmentService.TGetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.DepartmentName,
                                                   Value = x.DepartmentID.ToString(),
                                               }).ToList();
            ViewBag.department = department;
            return View();
        }

        [HttpPost]
        public IActionResult AddStaff(Staff p)
        {
            List<SelectListItem> department = (from x in _departmentService.TGetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.DepartmentName,
                                                   Value = x.DepartmentID.ToString(),
                                               }).ToList();
            ViewBag.department = department;
            StaffValidator validator = new StaffValidator();
            var result = validator.Validate(p);
            if (result.IsValid)
            {
                p.Status = true;
                _staffService.TInsert(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }



        }

        [HttpGet]
        public IActionResult UpdateStaff(int id)
        {
            List<SelectListItem> department = (from x in _departmentService.TGetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.DepartmentName,
                                                   Value = x.DepartmentID.ToString(),
                                               }).ToList();
            ViewBag.department = department;
            var values = _staffService.TGetByID(id);
            return View(values);

        }

        [HttpPost]
        public IActionResult UpdateStaff(Staff p)
        {
            List<SelectListItem> department = (from x in _departmentService.TGetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.DepartmentName,
                                                   Value = x.DepartmentID.ToString(),
                                               }).ToList();
            ViewBag.department = department;
            StaffValidator validator2 = new StaffValidator();
            var result2 = validator2.Validate(p);
            if (result2.IsValid)
            {
                p.Status = true;
                _staffService.TUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result2.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
           
        }

        public IActionResult DeleteStaff(int id)
        {
            var values = _staffService.TGetByID(id);
            if (values.Status == true)
            {
                values.Status = false;
                _staffService.TUpdate(values);
            }
            else
            {
                values.Status = true;
                _staffService.TUpdate(values);
            }


            return RedirectToAction("Index");
        }
    }
}
