using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCity { get; set; }
        
        [Required]
        [MaxLength(100)]
        public String Name { get; set; }
        
        [MaxLength(100)]
        public int? Population { get; set; }
        
        public ICollection<Artist> Artists { get; set; }
    }
}