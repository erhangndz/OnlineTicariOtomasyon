using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OnlineTicariOtomasyon.Controllers
{
    public class StatisticsController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            ViewBag.d1= c.Currents.Count();
            ViewBag.d2= c.Products.Count();
            ViewBag.d3= c.Staffs.Count();
            ViewBag.d4= c.Categories.Count();
            ViewBag.d5= c.Products.Sum(x=>x.Stock);
            ViewBag.d6= c.Products.Select(x=>x.Brand).Distinct().Count();
            ViewBag.d7= c.Products.Count(x => x.Stock < 20);
            ViewBag.d8 = c.Products.OrderByDescending(x=>x.SalePrice).Select(x=>x.ProductName).First();
            ViewBag.d9 = c.Products.OrderBy(x => x.SalePrice).Select(x => x.ProductName).First();
            ViewBag.d10 = c.Products.Where(x=>x.ProductName=="Buzdolabı").Sum(x=>x.Stock);
            ViewBag.d11 = c.Products.Where(x=>x.ProductName=="Laptop").Sum(x=>x.Stock);
            //Max Ürünlü Marka
            ViewBag.d12 = c.Products.GroupBy(x=>x.Brand).OrderByDescending(x=>x.Count()).Select(x=>x.Key).First();
            //En çok satan ürün
            ViewBag.d13 = c.Products.Where(x => x.ProductID == (c.Transactions.GroupBy(x => x.ProductID).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault())).Select(x => x.ProductName).First(); 
            //Kasadaki tutar
            ViewBag.d14 = c.Transactions.Sum(x => x.TotalPrice);
            //Bugünkü satışlar
            ViewBag.d15 =  c.Transactions.Count(x => x.Date == DateTime.Today);
            //Bugünkü kasa
            ViewBag.d16 = c.Transactions.Where(x => x.Date == DateTime.Today).Sum(x => x.TotalPrice);
            return View();
        }
    }
}
