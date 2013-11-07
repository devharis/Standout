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
        public String PostCode { get; set; }
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
        public int Lat { get; set; }
        [Required]
        [Display(Name = "Longitude")]
        public int Lng { get; set; }
    }
}