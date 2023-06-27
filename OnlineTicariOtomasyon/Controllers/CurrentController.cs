using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CurrentController : Controller
    {
        private readonly ICurrentService _currentService;
        private readonly ITransactionService _transactionService;

        public CurrentController(ICurrentService currentService, ITransactionService transactionService)
        {
            _currentService = currentService;
            _transactionService = transactionService;
        }

        public IActionResult Index()
        {
            var values = _currentService.TGetList().OrderByDescending(x=>x.Status).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCurrent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCurrent(Current p)
        {
            CurrentValidator validator=new CurrentValidator();
            ValidationResult result=validator.Validate(p);
            if (result.IsValid)
            {
                p.Status = true;
                _currentService.TInsert(p);
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

        public IActionResult DeleteCurrent(int id)
        {
            var values = _currentService.TGetByID(id);
            if (values.Status == true)
            {
                values.Status = false;
                _currentService.TUpdate(values);
            }
            else
            {
                values.Status = true;
                _currentService.TUpdate(values);
            }


            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCurrent(int id)
        {
            var values = _currentService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateCurrent(Current p)
        {
            CurrentValidator validator2 = new CurrentValidator();
            ValidationResult result2 = validator2.Validate(p);
            if (result2.IsValid)
            {
                p.Status = true;
                _currentService.TUpdate(p);
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

        public IActionResult CurrentDetails(int id)
        {
            var values= _transactionService.TGetAll().Where(x=>x.CurrentID==id).ToList();
            var current = _currentService.TGetList().Where(x => x.CurrentID == id).Select(x => x.Name + " " + x.Surname).FirstOrDefault();
            ViewBag.current=current;
            return View(values);
        }

    }
}
