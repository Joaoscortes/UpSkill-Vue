using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
