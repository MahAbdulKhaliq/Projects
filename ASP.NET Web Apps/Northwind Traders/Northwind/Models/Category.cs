using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{

    public class Category
    {
        [Key]
        [Display(Name = "Category Id")]
        public int categoryId { get; set; }
        [Display(Name = "Category Name")]
        public string categoryName { get; set; }
    }

}
