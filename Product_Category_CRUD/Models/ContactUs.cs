using System.ComponentModel.DataAnnotations;

namespace Product_Category_CRUD.Models
{
    public class ContactUs
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Massage { get; set; }
    }
}
