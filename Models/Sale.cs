using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Sale
    {
        public int Id { get; set; }

        [Required]
        [Range(1,1000, ErrorMessage="{0} must be greater than {1} and less than {2}")]
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public DailyStock DailyStock { get; set; }
        public int DailyStockId { get; set; }
       
        public DateTime CreatedAt { get; set; }=DateTime.Now;
    }
}