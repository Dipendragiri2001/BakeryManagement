using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ClientNotifications;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using static ClientNotifications.Helpers.NotificationHelper;

namespace Project.Controllers
{
    public class ProductController :Controller
    {
        private ApplicationDbContext _context;
        private IClientNotification _client;

        public ProductController(ApplicationDbContext context,IClientNotification client)
        {
            _context=context;
            _client=client;
        }
        public IActionResult Index()
        {
            var products=_context.Products.Where(x=>x.Price>0).ToList();
            return View(products);
        }
        public IActionResult ViewPurchase()
        {
            var purchases= _context.Products.Where(x=>x.PurchaseName!=null).ToList();
            return View(purchases);
        }
        [HttpGet]
        public IActionResult New()
        {
            ViewBag.Message="New";
            return View(new Product());
        }
        [HttpPost]
        public IActionResult New(Product product,string message)
        {
              var existingproduct =_context.Products.FirstOrDefault(x=>x.ProductName.Equals(product.ProductName));
           if(!ModelState.IsValid){
               
                return View();
            }
             if(message.Equals("Update") ){
                _context.Products.Update(product);
                _context.SaveChanges();
                _client.AddSweetNotification("WELL DONE!! ","Your Data Has Been Successfully Saved",NotificationType.success);
             }
           
                else if(existingproduct != null)
                 {  
                     var pStock= _context.Products.FirstOrDefault(x=>x.ProductName.Equals(product.ProductName));
                     pStock.ProductName = product.ProductName;
                     pStock.Price= product.Price;
                _context.Products.Update(pStock);
                _context.SaveChanges();
                _client.AddToastNotification("WELL DONE!! Your Previous Data Has Been Successfully Updated",NotificationType.success,new ToastNotificationOption{
                    PositionClass="toast-top-right"
                });
            }
             _context.Products.Add(product);
                _context.SaveChanges();
                _client.AddToastNotification("WELL DONE!! Your  Data Has Been Successfully Updated",NotificationType.success,new ToastNotificationOption{
                    PositionClass="toast-top-right"
                });
                
            
            return RedirectToAction(nameof(New));
        }
        public IActionResult Update(int id)
        {
            ViewBag.Message="Update";
            var up=_context.Products.FirstOrDefault(x=>x.Id==id);
            return View(nameof(New),up);
            
        }

        public IActionResult Delete (int id) {

            var data = _context.Products.FirstOrDefault (x => x.Id == id);
            _context.Products.Remove(data);
            _context.SaveChanges();
            _client.AddToastNotification("WELL DONE!! Your Data Has Been Successfully Deleted",NotificationType.success,new ToastNotificationOption{
                    PositionClass="toast-top-right"
                });
            return RedirectToAction("Index");
        }
        
        public IActionResult Purchase()
        {
            ViewBag.Message="New";
            return View(new Product());
        }

        
       
        [HttpPost]
          public IActionResult Purchase(Product purchase,string message)
        {
            var existingData= _context.Products.Any(x=>x.ProductName.Equals(purchase.ProductName));
            if(message.Equals("Update") || existingData )
            {
                _context.Products.Update(purchase);
                _context.SaveChanges();
                _client.AddToastNotification("Purchase Items Update Successfully",NotificationType.success,null);
            }
            var productName = new Product();
            productName.PurchaseName=purchase.PurchaseName;
            _context.Products.Add(productName);
            _context.SaveChanges();
            return RedirectToAction("Purchase");
        }
        public IActionResult UpdatePurchase(int id)
        {
            ViewBag.Message="Update";
            var data = _context.Products.FirstOrDefault(x=>x.Id==id);
        
            return View(data);
        }
    }
}