using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWeb.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter customet's name.")]
        [StringLength(30)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Hobbies { get; set; }
        public string Gender { get; set; }
    }
}