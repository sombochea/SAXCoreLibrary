using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsoleApp.Models
{
    public class Employee : Identity
    {
        public decimal Salary { get; set; }
    }
}
