using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Project.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        
        [Remote(action: "VerifyName", controller: "Customer")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public List<Receipt> Receipts { get; set; }
        public List<DailyStock> DailyStock { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}