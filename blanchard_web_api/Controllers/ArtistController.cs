using blanchard_web_api.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace blanchard_web_api.Controllers
{
    [Route("api/[controller]")]
    [Tags("Artist databse API")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        IArtistRepository artistRepository;

        public ArtistController(IArtistRepository IartistRepository) { 
            artistRepository = IartistRepository;
        }
        // GET: api/<ArtistController>
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await artistRepository.GetAllAsync());
        }

        // GET api/<ArtistController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Artist artist = await artistRepository.GetByIdAsync(id);
            if (artist == null)
            {
                return Problem("Id inconnu");
            }
            else {
                return Ok(artist);
            }
        }

        // POST api/<ArtistController>
        [HttpPost]
        public async Task<IActionResult> Post(Artist artist)
        {
            return Ok(await artistRepository.Post(artist));
        }

        // PUT api/<ArtistController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Artist artist)
        {
            Artist artistDbb = await artistRepository.GetByIdAsync(artist.Id);
            if (artistDbb == null)
            {
                return Problem("id inconnu");
            }
            else {
                return Ok(await artistRepository.Put(artist));
            }
        }

        // DELETE api/<ArtistController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try {
                await artistRepository.DeleteByIdAsync(id);
            }
            catch{
                return Problem("id inconnu");
            }
            return Ok("deletion sucessful");
        }
    }
}
