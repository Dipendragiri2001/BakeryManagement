using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        [Required]
        [Range(1,1000, ErrorMessage="{0} Must be greater than{1} and less than {2}")]
        public int Quantity { get; set; }
        [Required]
        [Range(1,100000, ErrorMessage="{0} must be greater than {1} and less than {2}")]
        public long TotalAmount { get; set; }
        public decimal AmountOfOneQuantity { get; set; }
        public Supplier Supplier { get; set; }
        public int SupplierId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public List<MaterialStock> MaterialStock {get; set;}

        public DateTime CreatedAt { get; set; }=DateTime.Now;
        
    }
}