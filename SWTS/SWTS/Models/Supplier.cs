using System;
using System.ComponentModel.DataAnnotations;

namespace SWTS.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "required")]
        public String Name { get; set; }

        [Required(ErrorMessage = "required")]
        public String Address { get; set; }

        [Required(ErrorMessage = "required")]
        [Display(Name = "Post code")]
        [RegularExpression(@"^(s-|S-){0,1}[0-9]{3}\s?[0-9]{2}$)", ErrorMessage = "- Not a valid post code")]
        public int? PostCode { get; set; }

        [Required(ErrorMessage = "required")]
        public String City { get; set; }

        [Required(ErrorMessage = "required")]
        public String Country { get; set; }
        
        [Required(ErrorMessage = "required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$)", ErrorMessage = "- Invalid email format.")]
        public String Email { get; set; }

        [Required(ErrorMessage = "required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{10})", ErrorMessage = "- Not a valid number, must be 10 numbers")]
        public String Phone { get; set; }

        [Required(ErrorMessage = "required")]
        public String Category { get; set; }

        [Required]
        [Display(Name = "Latitude")]
        public double Lat { get; set; }
        [Required]
        [Display(Name = "Longitude")]
        public double Lng { get; set; }
    }
}