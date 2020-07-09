using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebApplication.DTO;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class EfDbService : DbService
    {
        private readonly MyDbContext _context;

        public EfDbService(MyDbContext context)
        {
            _context = context;
        }

        public Artist GetArtist(int id)
        {
            return _context.Artists.Find(id);
        }

        public ICollection<Painting> GetPaintingByArtist(int id)
        {
            return _context.Paintings.Where(p => p.IdArtist == id).OrderBy(p => p.CreatedAt).ToList();
        }

        public ICollection<Art_Movement> GetArtMovementByArtist(int id)
        {
            if (_context.ArtMovements.Where(p => p.IdArtist == id).ToList() != null)
            {
                return _context.ArtMovements.Where(p => p.IdArtist == id).ToList();
            }

            return _context.ArtMovements.Where(p => p.IdArtMovement == _context.Artists.Find(id).IdArtMovement).ToList();
        }


        public String PostArtist(ArtistRequest request)
        {
            if (_context.Cities.Find(request.idCity) == null)
            {
                return "NOCITY";
            }

            if (_context.ArtMovements.Find(request.idArtMovement) == null)
            {
                return "NOMOVE";
            }

            if (_context.Artists.Where(a => a.Nickname == request.nickname).Equals(null))
            {
                return "NICK";
            }
            
            Artist NewArtist = new Artist();
            NewArtist.City = _context.Cities.Find(request.idCity);
            NewArtist.FirstName = request.firstName;
            NewArtist.LastName = request.lastName;
            NewArtist.Nickname = request.nickname;
            NewArtist.DateOfBirth = request.dateOfBirth;
            NewArtist.ArtMovement = _context.ArtMovements.Find(request.idArtMovement);
            _context.Artists.Add(NewArtist);
            _context.SaveChanges();

            return "SUCCESS";
        }
    }
}