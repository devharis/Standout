using System;
using System.ComponentModel.DataAnnotations;

namespace SWTS.Models
{
    public class Supplier
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public String Address { get; set; }
        [Required]
        [Display(Name = "Post code")]
        public int PostCode { get; set; }
        [Required]
        public String City { get; set; }
        [Required]
        public String Country { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String Phone { get; set; }

        [Required]
        [Display(Name = "Latitude")]
        public double Lat { get; set; }
        [Required]
        [Display(Name = "Longitude")]
        public double Lng { get; set; }
    }
}