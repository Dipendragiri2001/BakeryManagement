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
    public class SaleController : Controller {

        private ApplicationDbContext _context;
        private IClientNotification _client;

        public SaleController (ApplicationDbContext context, IClientNotification client) {
            _context = context;
            _client = client;
        }

        public IActionResult Index () {
            var sales = _context.Sales.Where(x=>x.CreatedAt.ToShortDateString().Equals(DateTime.Now.ToShortDateString())).Include (x => x.DailyStock).Include(x=>x.DailyStock.Product).Include (x => x.Customer).ToList ();
            var customers = _context.Customers.ToList();
            ViewBag.Customers = new SelectList(customers,"Id","FirstName");

            ViewBag.Total = sales.Sum(x=>x.TotalAmount);
            return View (sales);
        }
        public IActionResult SearchByDate(int customerId,string date=null)
        {
            var dt = Convert.ToDateTime(date);
            var customer = new List<Sale>();

            if(customerId>0 && !string.IsNullOrEmpty(date)){
                customer = _context.Sales.Where(x=>x.CreatedAt.ToShortDateString().Equals(dt.ToShortDateString())&& x.Quantity>0 && x.CustomerId == customerId)
                                .Include(x=>x.Customer ).Include(x=>x.DailyStock.Product).ToList();
            }
            
            if(customerId<=0 && !string.IsNullOrEmpty(date)){
                customer = _context.Sales.Where(x=>x.CreatedAt.ToShortDateString().Equals(dt.ToShortDateString())&& x.Quantity>0).Include(x=>x.Customer ).Include(x=>x.DailyStock.Product).ToList();
            } 

            if(customerId>0 && string.IsNullOrEmpty(date)){
                customer = _context.Sales.Where(x=>x.Quantity>0 && x.CustomerId==customerId).Include(x=>x.Customer ).Include(x=>x.DailyStock.Product).ToList();
            }

            
            //var customer = _context.Sales.Where(x=>x.CreatedAt.ToShortDateString().Equals(dt.ToShortDateString())&& x.Quantity>0).Include(x=>x.Customer ).Include(x=>x.DailyStock.Product).ToList();
            ViewBag.DateValue= date;

             var customers = _context.Customers.ToList();
            ViewBag.Customers = new SelectList(customers,"Id","FirstName");

            ViewBag.Total = customer.Sum(x=>x.TotalAmount);
            return View("Index",customer);
        }
        public IActionResult New ()
        {
            LoadDailyStockAndCustomer();

            return View(new Sale());
        }

        private void LoadDailyStockAndCustomer()
        {
            var customers = _context.Customers.ToList();

            var dailyStock = _context.DailyStocks
                .Where(x => x.CreatedAt.ToShortDateString().Equals(DateTime.Now.ToShortDateString()) && x.Quantity>0)
                .Include(x => x.Product).ToList();

            ViewBag.Customer = new SelectList(customers, "Id", "FirstName");
            ViewBag.DailyStock = new SelectList(dailyStock, "Id", "Product.ProductName");
        }

        [HttpPost]
        public IActionResult New (Sale sale) {
            if(!ModelState.IsValid){
                LoadDailyStockAndCustomer();
                return View();
            }

            var productOfDailyStock = _context.DailyStocks.Include(x=>x.Product).FirstOrDefault(x=>x.Id == sale.DailyStockId);

            var unitPrice = _context.Products.FirstOrDefault(x=>x.Id == productOfDailyStock.Product.Id).Price;

            sale.TotalAmount = sale.Quantity * unitPrice;

            _context.Sales.Add (sale);

            var dailyStock = _context.DailyStocks.FirstOrDefault (x => x.Id == sale.DailyStockId);

            if (dailyStock.Quantity - sale.Quantity >= 0) {
                dailyStock.Quantity = dailyStock.Quantity - sale.Quantity;
                _context.SaveChanges ();
                return RedirectToAction (nameof (New));
            }
             else {
                _client.AddToastNotification ($"Stock not available. Only @{dailyStock.Quantity} left.", NotificationType.error, null);
                 LoadDailyStockAndCustomer();
                return View (sale);
            }

        }
    }
}