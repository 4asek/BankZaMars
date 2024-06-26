﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Models;

namespace WebApplication2.Data.Models
{
    public class Account
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double Balance { get; set; }
        // public List<Transactions> Transactions { get; set; }
        public List<Card> Cards { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("Customer")]
        public Guid CustomerID { get; set; }
        public virtual Employee Employees { get; set; }

        [ForeignKey("Employees")]
        public Guid EmployeeID { get; set; }
    }

}
