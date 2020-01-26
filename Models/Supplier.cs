using System;
using System.Collections.Generic;

namespace Project.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; } 
        public List<Purchase> Purchase { get; set; }
        public List<Payment> Payments { get; set; } 
        public DateTime CreatedAt { get; set; }=DateTime.Now;

    }
}