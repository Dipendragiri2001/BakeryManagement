using System;

namespace Project.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public int Amount { get; set; }   
        public DateTime PaymentDate { get; set; }    
        public Customer Customer { get; set; }
        public int CustomerId { get; set; } 
        public DateTime CreatedAt { get; set; }=DateTime.Now;
    }
}