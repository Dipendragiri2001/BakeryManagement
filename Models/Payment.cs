using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Payment
    {
        public int Id { get; set; }
        [Required]
        [Range(1,1000, ErrorMessage="{0} must be greater than {1} and less than {2}")]
        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }
        public Supplier Supplier { get; set; }
        public int SupplierId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}