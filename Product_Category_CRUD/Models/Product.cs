using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Product_Category_CRUD.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string? Imageurl { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public int Cid { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string Cname { get; set; }

    }
}

