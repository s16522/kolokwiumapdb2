using System;
using Microsoft.AspNetCore.Mvc;
using WebApplication.DTO;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    [Microsoft.AspNetCore.Components.Route(("api/artists"))] 
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly EfDbService _service;

        public ArtistController (EfDbService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetArtist(int id)
        {
            var artist = _service.GetArtist(id);
            if (artist == null)
            {
                return NotFound();
            }
            
            ArtistResponse artistResponse = new ArtistResponse();
            artistResponse.Artist = artist;
            artistResponse.Paintings = _service.GetPaintingByArtist(id);
            artistResponse.ArtMovements = _service.GetArtMovementByArtist(id);
            return Ok(artistResponse);
        }
        
        [HttpPost]
        public IActionResult PostArtist(ArtistRequest request)
        {

            var response = _service.PostArtist(request);

            switch (response)
            {
                case "NOCITY":
                    return NotFound("No such city");
                case "NOMOVE":
                    return NotFound("No such art movement");
                case "NICK":
                    return BadRequest("Nickname already exists");
                case "SUCCESS":
                    return Ok(response);
                default:
                    return Ok(response);
            }
        }
    }
}