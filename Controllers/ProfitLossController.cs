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
    public class ProfitLossController : Controller {
        private readonly ApplicationDbContext _context;
        private IClientNotification _client;

        public ProfitLossController (ApplicationDbContext context, IClientNotification client) {
            _client = client;
            _context = context;
        }

        public IActionResult SearchByDate (int customerId,string date = null) {
            var dt = Convert.ToDateTime (date);

            var profitLoss = _context.ProfitLosses
                .Where (x => (x.CreatedAt.ToShortDateString ().Equals (dt.ToShortDateString ())))
                .ToList ();
            
            ViewBag.DateValue = date;
            
             var customers = _context.Customers.ToList();
            ViewBag.Customers = new SelectList(customers,"Id","FirstName");
            return View ("Index", profitLoss);
        }

        public IActionResult Monthly()
        {
            var d= _context.ProfitLosses.ToList ();

            return View(d);
        }
        public IActionResult Index () {
            Calculate();

           var d= _context.ProfitLosses.ToList ();
            
            return View (d);
        }
        public void Calculate () {
            // do your calculations...
             var data = _context.ProfitLosses.FirstOrDefault(x=>x.CreatedAt.ToShortDateString().Equals(DateTime.Now.ToShortDateString()));
            
            var materialsUsedTodayTotalPrice = _context.DailyMaterialsUsed
                .Where (x => x.CreatedAt.ToShortDateString ().Equals (DateTime.Now.ToShortDateString ()))
                .Sum (x => x.TotalPrice);

            var soldItemsTotalPriceToday = _context.Sales.Where (x => x.CreatedAt.ToShortDateString ().Equals (DateTime.Now.ToShortDateString ()))
                .Sum (x => x.TotalAmount);

            var ProfitLoss = soldItemsTotalPriceToday - materialsUsedTodayTotalPrice;




            var model = new ProfitLoss {  ProfitOrLoss = ProfitLoss };
            
            model.TotalMaterialUsedToday = materialsUsedTodayTotalPrice;
            model.TotalSaledToday= soldItemsTotalPriceToday;


            if(data!=null && data.CreatedAt.ToShortDateString().Equals(DateTime.Now.ToShortDateString())){
                data.TotalMaterialUsedToday =  materialsUsedTodayTotalPrice;
                data.TotalSaledToday =  soldItemsTotalPriceToday;
                data.ProfitOrLoss =  ProfitLoss;

                _context.ProfitLosses.Update(data);
            }else{
            _context.ProfitLosses.Add(model);
            }

            _context.SaveChanges();
            
             
            
         
            //return RedirectToAction ("Index");
        }
    }
}