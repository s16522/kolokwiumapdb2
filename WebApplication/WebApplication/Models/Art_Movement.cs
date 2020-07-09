using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class Art_Movement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdArtMovement { get; set; }
        
        [Required]
        [ForeignKey("IdArtMovement")]
        public int IdNextArtMovement { get; set; }
        
        public Art_Movement ArtMovement { get; set; }
        
        [ForeignKey("IdMovementFounder")]
        public int IdArtist { get; set; }
        
        [Required]
        [MaxLength(100)]
        public String Name { get; set; }
        
        [Required]
        public DateTime DateFounded { get; set; }

        public ICollection<Art_Movement> Art_Movements;
        public ICollection<Artist> Artists;
    }
}