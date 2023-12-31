﻿using System.ComponentModel.DataAnnotations;

namespace EmployeeAPIWithCFA.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Designation { get; set; }

        public int Salary { get; set; }

        [EmailAddress]
        [Required]
        [MaxLength(50)]
        public string EmailId { get; set; }

    }
}
