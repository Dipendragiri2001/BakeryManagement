using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Product
    {
        public int Id { get; set; } 
        public string ProductName { get; set; }
        [Required]
        [Range(1,1000, ErrorMessage="{0} must be greater than {1} and less than {2}")]
        public int Price { get; set; }  
        public string PurchaseName { get; set; }
        public List<Purchase> Purchases { get; set; }
        public List<Payment> Payments {get; set;}
        public List<DailyStock> DailyStocks { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}