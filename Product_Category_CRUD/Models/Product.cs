using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string? Imageurl { get; set; }
        [Required]
        [Display(Name = "Category Cid")]
        public int Cid { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string Cname { get; set; }
        [NotMapped]
        public int Quantity { get; set; }
        [NotMapped]
        public int? CartId { get; set; }

        [NotMapped]
        public DateTime? DateTime { get; set; }

        [NotMapped]
        public int OrderId { get; set; }

        public int Uid { get; set; }

    }
}

