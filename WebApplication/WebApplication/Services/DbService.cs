using System;
using System.Collections.Generic;
using WebApplication.DTO;
using WebApplication.Models;

namespace WebApplication.Services
{
    public interface DbService
    {
        public Artist GetArtist(int id);

        public ICollection<Painting> GetPaintingByArtist(int id);

        public ICollection<Art_Movement> GetArtMovementByArtist(int id);
        public String PostArtist(ArtistRequest request);
    }
}