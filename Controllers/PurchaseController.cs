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
    public class PurchaseController : Controller {
        private ApplicationDbContext _context;
        private IClientNotification _client;

        public PurchaseController (ApplicationDbContext context, IClientNotification client) {
            _context = context;
            _client = client;
        }
        public IActionResult Index () {
              var  customer = _context.Purchases.Include(x=>x.Product).Include(x=>x.Supplier).ToList();
                  var suppliers = _context.Suppliers.ToList();
            
            ViewBag.Total = customer.Sum(x=>x.TotalAmount);
            return View (customer);
        }
         public IActionResult SearchByDate(int supplierId,string date=null)
        {
            var dt = Convert.ToDateTime(date);
            var supplier = new List<Purchase>();

            if(supplierId>=0 && !string.IsNullOrEmpty(date)){
                supplier = _context.Purchases.Where(x=>x.CreatedAt.ToShortDateString().Equals(dt.ToShortDateString())&& x.Quantity>0 && x.Id == supplierId)
                                .Include(x=>x.Product ).ToList();
            }
            
            if(supplierId<=0 && !string.IsNullOrEmpty(date)){
                supplier = _context.Purchases.Where(x=>x.CreatedAt.ToShortDateString().Equals(dt.ToShortDateString())&& x.Quantity>0).Include(x=>x.Product ).ToList();
            } 

            if(supplierId>0 && string.IsNullOrEmpty(date)){
                supplier = _context.Purchases.Where(x=>x.Quantity>0 && x.Id==supplierId).Include(x=>x.Product).ToList();
            }

            
            //var supplier = _context.Sales.Where(x=>x.CreatedAt.ToShortDateString().Equals(dt.ToShortDateString())&& x.Quantity>0).Include(x=>x.Customer ).Include(x=>x.DailyStock.Product).ToList();
            ViewBag.DateValue= date;

             var suppliers = _context.Suppliers.ToList();
            ViewBag.Suppliers = new SelectList(suppliers,"Id","FirstName");

            ViewBag.Total = supplier.Sum(x=>x.TotalAmount);
            return View("Index",supplier);
        }
        public IActionResult New () {
            Load();
            return View (new Purchase());
        }
         private void Load()
        {
             var suppliers = _context.Suppliers.ToList ();
            ViewBag.Suppliers = new SelectList (suppliers, "Id", "FirstName");
            var products = _context.Products.Where (x => x.PurchaseName != null).ToList ();
            ViewBag.Products = new SelectList (products, "Id", "PurchaseName");
        }
        [HttpPost]
        public IActionResult New (Purchase purchase) {
            var productName = _context.Products.FirstOrDefault (x => x.Id == purchase.ProductId).PurchaseName;
            var ratePerKg = purchase.TotalAmount / purchase.Quantity;

            var existingPurchase = _context.MaterialStocks.FirstOrDefault (x => x.ProductName.Equals (productName));
            if (existingPurchase != null) {
                var mStock = _context.MaterialStocks.FirstOrDefault (x => x.ProductName.Equals (productName));
                mStock.Quantity = mStock.Quantity + purchase.Quantity;
                mStock.TotalAmount = mStock.TotalAmount + purchase.TotalAmount;
                mStock.RatePerKg = mStock.TotalAmount / mStock.Quantity;
                _context.Update (mStock);
                _context.SaveChanges ();
                Load();
                _client.AddToastNotification ("Congratulations, You Data HAs been SucessFully Added", NotificationType.success, null);


            } else {
                var materialStock = new MaterialStock ();
                materialStock.ProductName = productName;
                materialStock.Quantity = purchase.Quantity;
                materialStock.TotalAmount = purchase.TotalAmount;
                materialStock.RatePerKg = ratePerKg;
                _context.MaterialStocks.Add (materialStock);
                _context.SaveChanges ();
                Load();
                _client.AddToastNotification ("Congratulations, You Data HAs been SucessFully Added", NotificationType.success, null);

            }
            
        
           purchase.AmountOfOneQuantity = ratePerKg;
            _context.Purchases.Add (purchase);

            _context.SaveChanges ();
            Load();
            _client.AddToastNotification ("Congratulations, You Data HAs been SucessFully Added", NotificationType.success, null);
            return View ();
        }

    }
}