using System;

namespace Project.Models
{
    public class ProfitLoss
    {
        public int Id { get; set; }
        public decimal ProfitOrLoss { get; set; }
        public decimal TotalMaterialUsedToday { get; set; }
        public decimal TotalSaledToday { get; set; }
        public DateTime CreatedAt { get; set; }=DateTime.Now;
    }
}