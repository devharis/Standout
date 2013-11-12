using System;
using System.ComponentModel.DataAnnotations;

namespace SWTS.Models
{
    /// <summary>
    ///  This class is a model for a Supplier. 
    ///  It uses data annotations for validation.
    /// </summary>
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
        [RegularExpression(@"^(\d{5})$", ErrorMessage = "Invalid postal code")]
        public int? PostCode { get; set; }

        [Required(ErrorMessage = "required")]
        public String City { get; set; }

        [Required(ErrorMessage = "required")]
        public String Country { get; set; }
        
        [Required(ErrorMessage = "required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public String Email { get; set; }

        [Required(ErrorMessage = "required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^((\+\d{1,3}(-| )?\(?\d\)?(-| )?\d{1,5})|(\(?\d{2,6}\)?))(-| )?(\d{3,4})(-| )?(\d{4})(( x| ext)\d{1,5}){0,1}$", ErrorMessage = "Invalid Phone Number!")]
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