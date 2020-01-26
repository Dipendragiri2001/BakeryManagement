using System;
using System.Collections.Generic;

namespace Project.Models
{
    public class DailyStock
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }    

        public List<Sale> Sales { get; set; } 
        public DateTime CreatedAt { get; set; }=DateTime.Now;
        
    }
}