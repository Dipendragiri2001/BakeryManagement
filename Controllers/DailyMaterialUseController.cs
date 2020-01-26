
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ClientNotifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Data;
using Project.Models;
using Microsoft.EntityFrameworkCore;
using static ClientNotifications.Helpers.NotificationHelper;
namespace Project.Controllers
{
    public class DailyMaterialUseController:Controller
    {

        private ApplicationDbContext _context;
        private IClientNotification _client;

        public DailyMaterialUseController (ApplicationDbContext context, IClientNotification client) {
            _context = context;
            _client = client;
        }
        public IActionResult Index()
        {
            var materials= _context.DailyMaterialsUsed.Where(x=>x.CreatedAt.ToShortDateString().Equals(DateTime.Now.ToShortDateString())).Include(x=>x.MaterialStock).ToList();
            return View(materials);
        }
        public IActionResult SearchByDate(string date=null)
    
        {
            var dt=Convert.ToDateTime(date);
            var materials= _context.DailyMaterialsUsed.Where(x=>x.CreatedAt.ToShortDateString().Equals(dt.ToShortDateString())).Include(x=>x.MaterialStock).ToList();
            ViewBag.DateValue= date;
            return View("Index",materials);
        }

        public IActionResult New()
        {
           
             LoadMaterialStock();
            return View(new DailyMaterialUse());
        }
        [HttpPost]
        public IActionResult New(DailyMaterialUse addmaterials)
        {
            var unitPrice = _context.MaterialStocks.FirstOrDefault(x=>x.Id == addmaterials.MaterialStockId).RatePerKg;
            addmaterials.TotalPrice = addmaterials.Quantity * unitPrice;

            _context.DailyMaterialsUsed.Add(addmaterials);

            var materialStock= _context.MaterialStocks.FirstOrDefault(x=>x.Id==addmaterials.MaterialStockId);
            if(materialStock.Quantity - addmaterials.Quantity >=0){
                materialStock.Quantity= materialStock.Quantity- addmaterials.Quantity;
                
                _context.SaveChanges();
                return RedirectToAction(nameof(New));
            }
        
            else{
                _client.AddToastNotification($"Stock Not Available Only @{materialStock.Quantity} Available ",NotificationType.success,null);
                LoadMaterialStock();
                return View(addmaterials);
            }
            
            
        }
        private void LoadMaterialStock()
        {
            var load = _context.MaterialStocks.ToList();
            ViewBag.Products= new SelectList (load,"Id","ProductName");
        } 
        
    }
}