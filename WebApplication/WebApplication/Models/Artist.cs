using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdArtist { get; set; }
        
        [Required]
        [ForeignKey("IdArtMovement")]
        public int IdArtMovement { get; set; }
        
        public Art_Movement ArtMovement { get; set; }
        
        [ForeignKey("IdCityOfBirth")]
        public int IdCityOfBirth { get; set; }
        
        public City City { get; set; }
        
        [Required]
        [MaxLength(100)]
        public String FirstName { get; set; }
        
        [Required]
        [MaxLength(100)]
        public String LastName { get; set; }
        
        [MaxLength(100)]
        public String Nickname { get; set; }
        
        [Required]
        public DateTime DateOfBirth { get; set; }
        
        [NotMapped]
        public ICollection<Painting> Paintings { get; set; }
    }
}