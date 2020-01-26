using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ClientNotifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using static ClientNotifications.Helpers.NotificationHelper;

namespace Project.Controllers {
    
    public class DailyStockController : Controller {
        private ApplicationDbContext _context;
        private IClientNotification _client;

        public DailyStockController (ApplicationDbContext context, IClientNotification client) {
            _context = context;
            _client = client;

        }
        public IActionResult Index () {
            var dailyStocks = _context.DailyStocks
                .Where (x => x.CreatedAt.ToShortDateString ().Equals (DateTime.Now.ToShortDateString ()) && x.Quantity > 0)
                .Include (y => y.Product).ToList ();

            return View (dailyStocks);
        }

        public IActionResult SearchByDate (string date = null) {
            var dt = Convert.ToDateTime (date);

            var dailyStocks = _context.DailyStocks
                .Where (x => (x.CreatedAt.ToShortDateString ().Equals (dt.ToShortDateString ())) && x.Quantity > 0)
                .Include (y => y.Product).ToList ();

            ViewBag.DateValue = date;

            return View ("Index", dailyStocks);
        }
        public IActionResult New () {
            var products = _context.Products.Where (x => x.ProductName != null).ToList();
            ViewBag.Message="New";
            ViewBag.ProductName = new SelectList (products, "Id", "ProductName");
           
            return View ();
        }
        [HttpPost]
        public IActionResult Create (DailyStock dailyStock ,string message) {
           
           var existingData = _context.Products.FirstOrDefault(x=>x.Id== dailyStock.ProductId).ProductName;
           var check = _context.DailyStocks.FirstOrDefault(x=>x.Product.ProductName.Equals(existingData));
           if(existingData!=null){
                    _client.AddToastNotification("Data Already Exist",NotificationType.success,null);

           }
           else if(  message.Equals("Update") )  {
                
                    _context.DailyStocks.Update(dailyStock);
                    _context.SaveChanges();
                    _client.AddToastNotification("SuccessFully Updated",NotificationType.success,null);

            } 
             
                
            _context.DailyStocks.Add (dailyStock);
             _context.SaveChanges ();
            _client.AddToastNotification("SuccessFully Added",NotificationType.success,null);
             
            return RedirectToAction ("New");
        }
        public IActionResult Delete (int id) {

            var data = _context.DailyStocks.FirstOrDefault (x => x.Id == id);
            _context.DailyStocks.Remove (data);
            _context.SaveChanges ();

            return RedirectToAction ("Index");
        }

        public IActionResult Update(int id ,string name )
        {
            ViewBag.Message="Update";

             var products = _context.Products.Where (x => x.ProductName != null).ToList ();
            
            ViewBag.ProductName = new SelectList (products, "Id", "ProductName");

            var dt= _context.DailyStocks.Include(x=>x.Product).FirstOrDefault(x=>x.Id==id);

            return View(nameof(New),dt);
        }
    }
}