using System;

namespace WebApplication.DTO
{
    public class ArtistRequest
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string nickname { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int idCity { get; set; }
        public int idArtMovement { get; set; }
    }
}