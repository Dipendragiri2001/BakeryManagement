using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ClientNotifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private IClientNotification _client;

        public HomeController(ApplicationDbContext context, IClientNotification client)
        {
            _context = context;
            _client = client;

        }
        public IActionResult Index()
        {
            var data = _context.ProfitLosses.FirstOrDefault(x => x.CreatedAt.ToShortDateString().Equals(DateTime.Now.ToShortDateString()));
            if (data != null && data.CreatedAt.ToShortDateString().Equals(DateTime.Now.ToShortDateString()))
            {
                ViewBag.ProfitLoss = data.ProfitOrLoss;
            }

            var dt = DateTime.Now.ToString("MM");

            var dm = _context.ProfitLosses.Where(x => x.CreatedAt.ToString("MM").Equals(dt));

            ViewBag.monthlyData = dm.Sum(x => x.ProfitOrLoss);
            // var bun = _context.DailyStocks.ToList();
            // var data = bun.Where(x=>x.ProductName.Equals(bun)).ToList();

            // var b=_context.DailyStocks.FirstOrDefault(x=>x.CreatedAt.ToShortDateString().Equals(DateTime.Today.ToShortDateString()) && x.Product.ProductName.Equals("Bread") ) ;
            //  var c=_context.DailyStocks.FirstOrDefault(x=>x.CreatedAt.ToShortDateString().Equals(DateTime.Today.ToShortDateString()) && x.Product.ProductName.Equals("Pastry") ) ;

            // var d=_context.DailyStocks.FirstOrDefault(x=>x.CreatedAt.ToShortDateString().Equals(DateTime.Today.ToShortDateString()) && x.Product.ProductName.Equals("Bun") ) ;


            // ViewBag.Bread = b.Quantity;
            // ViewBag.Bun = d.Quantity;
            // ViewBag.Pastry = c.Quantity;



            var lowStock = _context.DailyStocks.Where(x => x.CreatedAt.ToShortDateString().Equals(DateTime.Today.ToShortDateString()));
            var aa = lowStock.Sum(x => x.Quantity);
            if (aa < 20)
            {
                TempData["x"] = "Products are out of stock. Consider purchasing it.";
            }

            var lowM = _context.MaterialStocks.Where(x => x.CreatedAt.ToShortDateString().Equals(DateTime.Today.ToShortDateString()));
            var bb = lowM.Sum(x => x.Quantity);
            if (aa < 20)
            {
                TempData["y"] = "Materials are out of stock. Consider purchasing it.";
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
