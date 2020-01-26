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
using static ClientNotifications.Helpers.NotificationHelper;
namespace Project.Controllers
{
    public class SupplierController:Controller
    {
        private ApplicationDbContext _context;

        public SupplierController(ApplicationDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            var supplier= _context.Suppliers.ToList();
            return View(supplier);
        }
        [HttpGet]
        public IActionResult New()
        {
            ViewBag.Message="New";
            return View(new Supplier());
        }
        [HttpPost]
      public IActionResult New(Supplier suppliers,string message)
        {
           
             if(message.Equals("Update") ){
                _context.Suppliers.Update(suppliers);
                _context.SaveChanges();         
             }
                else
                 {                 
                _context.Suppliers.Add(suppliers);
                _context.SaveChanges();
                
            }
                      
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            ViewBag.Message="Update";
            var up=_context.Suppliers.FirstOrDefault(x=>x.Id==id);
            return View(nameof(New),up);
            
        }

    }
}