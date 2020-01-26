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
namespace Project.Controllers {
    public class CustomerController : Controller {
        private ApplicationDbContext _context;

        public CustomerController (ApplicationDbContext context) {
            _context = context;
        }
        public IActionResult Index () {
            var customers = _context.Customers.ToList ();
            return View (customers);
        }

        [HttpGet]
        public IActionResult New () {
            ViewBag.Message = "New";
            return View (new Customer ());
        }

        [HttpPost]
        public IActionResult New (Customer customers, string message) {
            if (!ModelState.IsValid)
                return View (customers);

            try {
                if (message.Equals ("Update")) {
                    _context.Customers.Update (customers);
                    _context.SaveChanges ();
                } else {
                    _context.Customers.Add (customers);
                    _context.SaveChanges ();

                }
            } catch (Exception) {

            }

            return RedirectToAction (nameof (Index));
        }
        public IActionResult Update (int id) {
            ViewBag.Message = "Update";
            var up = _context.Customers.FirstOrDefault (x => x.Id == id);
            return View (nameof (New), up);

        }

        public IActionResult VerifyName (string firstName) {
            var check = _context.Customers.Any (x => x.FirstName.ToLower ().Equals (firstName.ToLower ()));
            if (check) {
                return Json ($"The Customer with name {firstName} already exists in database. Please try another name");
            }

            return Json (true);
        }

        public IActionResult Delete (int id) {
            try {
                var customerToDelete = _context.Customers.FirstOrDefault (x => x.Id == id);
                _context.Customers.Remove (customerToDelete);
                _context.SaveChanges ();
                return Ok ();
            } catch (Exception) {
                return BadRequest ();
            }
        }

    }
}