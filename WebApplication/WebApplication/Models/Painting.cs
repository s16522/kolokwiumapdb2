using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class Painting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPainting { get; set; }
        
        [MaxLength(100)]
        public String SurfaceType { get; set; }
        
        [MaxLength(100)]
        public String PaintingMedia { get; set; }

        [Required]
        [ForeignKey("IdArtist")]
        public int IdArtist { get; set; }

        public Artist Artist { get; set; }

        [ForeignKey("IdCoAuthor")]
        public int? IdCoAuthor { get; set; }

        public Artist CoArtist { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
    }
}