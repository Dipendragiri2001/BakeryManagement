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
namespace Project.Controllers
{
    public class ReceiptController:Controller
    {
        private IClientNotification _client;
        private ApplicationDbContext _context;

        public ReceiptController(ApplicationDbContext context,IClientNotification client)
        {
            _client=client;
            _context=context;
        }
        public IActionResult Index()
        {
            var receipt = _context.Receipts.Include(x=>x.Customer).ToList();
             var customers = _context.Customers.ToList();
             var sta= new List<Receipt>();
            ViewBag.Customers = new SelectList(customers,"Id","FirstName");
            
            ViewBag.Total = receipt.Sum(x=>x.Amount);
            ViewBag.SearchMode = "false";
            
            
            return View(receipt);
        }
        public IActionResult New()
        {
            var customer = _context.Customers.ToList();
            ViewBag.Customer = new SelectList(customer, "Id","FirstName");

            return View(new Receipt());
        }
        public IActionResult Search(int customerId)
        {
            var customer = new List<Receipt>();
                customer= _context.Receipts.Where (x=> x.Amount>0 && x.CustomerId==customerId)
                .Include(x=>x.Customer)
                .ToList();

            var salesOfCustomer = _context.Sales.Where(x=>x.CustomerId == customerId);

            ViewBag.TotalPaidByCustomer = customer.Sum(x=>x.Amount);
            ViewBag.TotalSoldToCustomer = salesOfCustomer.Sum(x=>x.TotalAmount);
            
            if(ViewBag.TotalSoldToCustomer>ViewBag.TotalPaidByCustomer){
            ViewBag.TotalDue= ViewBag.TotalSoldToCustomer-ViewBag.TotalPaidByCustomer;
                
            }
            ViewBag.AdvancePaid = ViewBag.TotalPaidByCustomer-ViewBag.TotalSoldToCustomer;
            ViewBag.SearchMode = "true";
            
           
           var cust= _context.Customers.ToList();
            ViewBag.Customers= new SelectList(cust,"Id","FirstName");
            
            ViewBag.CustomerId = customerId;
            return View("Index",customer);
        }
        public IActionResult Create(Receipt receipt)
        {
            _context.Receipts.Add(receipt);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

         public IActionResult ReceiptRecord () {
            var payments = _context.Receipts.Include (x => x.Customer).ToList ();

            return View (payments);
        }
        public IActionResult SearchRecord (string startdate, string enddate) {
            var dt = Convert.ToDateTime (startdate);
            var dt1 = Convert.ToDateTime (enddate);
            var records = _context.Receipts.Where (x =>x.CreatedAt >= dt &&
                x.CreatedAt <= dt1).Include (x => x.Customer).ToList();

            ViewBag.DateValue = startdate;
            ViewBag.DateValue1 = enddate;
            
            ViewBag.Total= records.Sum(x=>x.Amount);
            return View ("ReceiptRecord", records);
        }

        
       
    }
}