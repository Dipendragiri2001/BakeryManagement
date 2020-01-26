using System;
using System.Collections.Generic;

namespace Project.Models
{
    public class MaterialStock
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string MeasurementUnit { get; set; }
        public decimal RatePerKg { get; set; }
        
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public List<DailyMaterialUse> DailyMaterialUses { get; set; }
        public DateTime CreatedAt { get; set; }=DateTime.Now;
    }
}