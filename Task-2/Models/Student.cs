using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_2.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}