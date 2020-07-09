using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.DTO
{
    public class ArtistResponse
    {
        public Artist Artist { get; set; }
        public ICollection<Painting> Paintings { get; set; }
        public ICollection<Art_Movement> ArtMovements { get; set; }
    }
}