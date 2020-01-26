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
    public class PaymentController : Controller {
        private ApplicationDbContext _context;

        public PaymentController (ApplicationDbContext context) {
            _context = context;
        }
        public IActionResult Index () {
            var payment = _context.Payments.Include (y => y.Supplier).ToList ();
            ViewBag.TotalPayment = payment.Sum (x => x.Amount);
            return View (payment);
        }
        public IActionResult SearchByDate (string date = null) {
            var dt = Convert.ToDateTime (date);

            var payments = _context.Payments
                .Where (x => (x.CreatedAt.ToShortDateString ().Equals (dt.ToShortDateString ())) && x.Amount > 0)
                .Include (y => y.Supplier).ToList ();

            ViewBag.DateValue = date;

            return View ("Index", payments);
        }
        public IActionResult New () {

            var supplier = _context.Suppliers.ToList ();
            ViewBag.Payments = new SelectList (supplier, "Id", "FirstName");

            return View (new Payment ());
        }
        public IActionResult Create (Payment payment) {

            _context.Payments.Add (payment);
            _context.SaveChanges ();
            return RedirectToAction ("Index");
        }

        public IActionResult PaymentRecord () {
            var payments = _context.Payments.Include (x => x.Supplier).ToList ();

            return View (payments);
        }
        public IActionResult SearchRecord (string startdate, string enddate) {
            var dt = Convert.ToDateTime (startdate);
            var dt1 = Convert.ToDateTime (enddate);
            var records = _context.Payments.Where (x => x.CreatedAt >= dt &&
                x.CreatedAt <= dt1).Include (x => x.Supplier).ToList();

            ViewBag.DateValue = startdate;
            ViewBag.DateValue1 = enddate;
            
            ViewBag.Total= records.Sum(x=>x.Amount);
            return View ("PaymentRecord", records);
        }

    }
}