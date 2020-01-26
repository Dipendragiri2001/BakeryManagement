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
    public class MaterialStockController : Controller {
        private ApplicationDbContext _context;
        private IClientNotification _client;

        public MaterialStockController (ApplicationDbContext context, IClientNotification client) {
            _context = context;
            _client = client;
        }
        public IActionResult Index () {

            var materials = _context.MaterialStocks.ToList ();

            return View (materials);
        }

        public IActionResult SearchByDate (string date = null) {
            var dt = Convert.ToDateTime (date);

            var materialStocks = _context.MaterialStocks
                .Where (x => (x.CreatedAt.ToShortDateString ().Equals (dt.ToShortDateString ())) && x.Quantity > 0)
                .ToList ();

            ViewBag.DateValue = date;

            return View ("Index", materialStocks);
        }

        public IActionResult New () {
            ViewBag.Message = "New";
            var stocks = _context.MaterialStocks.ToList ();

            return View (new MaterialStock ());
        }
        public IActionResult Update (int id) {
            ViewBag.Message = "Update";
            var up = _context.MaterialStocks.FirstOrDefault (x => x.Id == id);
            return View (nameof (New), up);

        }

        [HttpPost]
        public IActionResult New (MaterialStock materialStock, string message) {
            if (message.Equals ("Update")) {
                _context.MaterialStocks.Update (materialStock);
                _context.SaveChanges ();
                _client.AddToastNotification ("WELL DONE!! Your Data Has Been Successfully Updated", NotificationType.success, new ToastNotificationOption {
                    PositionClass = "toast-top-right"
                });
            } else {

                _context.MaterialStocks.Add (materialStock);
                _context.SaveChanges ();
            }
            return RedirectToAction ("Index");

        }
        public IActionResult Delete (int id) {

            var dat = _context.MaterialStocks.FirstOrDefault (x => x.Id == id);
            _context.MaterialStocks.Remove (dat);
            _context.SaveChanges ();
            _client.AddToastNotification ("WELL DONE!! Your Data Has Been Successfully Deleted", NotificationType.success, new ToastNotificationOption {
                PositionClass = "toast-bottom-right"
            });
            return RedirectToAction ("Index");
        }

    }
}