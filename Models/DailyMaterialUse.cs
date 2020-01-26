using System;

using System.Collections.Generic;

namespace Project.Models
{
    public class DailyMaterialUse
    {
        public int Id { get; set; }
        public string  MaterialName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }=DateTime.Now;
        public MaterialStock MaterialStock { get; set; }
        public int MaterialStockId { get; set; }
        
    }
}