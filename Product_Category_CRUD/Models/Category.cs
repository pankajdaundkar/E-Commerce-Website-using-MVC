using System.ComponentModel.DataAnnotations;

namespace Product_Category_CRUD.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int Cid { get; set; }
        [Required]
        public string Cname { get; set; }

    }
}
