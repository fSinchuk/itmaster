using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Models
{
    public class ProductCategories : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}
