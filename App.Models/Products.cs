using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace App.Models
{
    public class Products : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public double Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
     
        [ForeignKey("CategoryId")]
        public virtual ProductCategories ProductCateogry { get; set; }
    }
}
