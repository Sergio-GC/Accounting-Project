﻿using System.ComponentModel.DataAnnotations;

namespace EF_DTO
{
    public class Price
    {
        [Key]
        public int Id { get; set; }
        public string Label { get; set; }
        public double Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
