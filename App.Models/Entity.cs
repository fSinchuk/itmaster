using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
