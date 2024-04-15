﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Data.Models
{
    public class Transactions
    {
        [Key]
        public Guid Id { get; set; }
        public int AccID { get; set; }
        public DateTime TransactionDate { get; set; }
        public double Suma { get; set; }
    }
}// 