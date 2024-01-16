using Microsoft.AspNetCore.Mvc;

namespace blanchard_web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrackController : ControllerBase
    {
        ITrackRepository trackRepository;
        private readonly ILogger<TrackController> _logger;

        public TrackController(ILogger<TrackController> logger, ITrackRepository ItrackRepository)
        {
            trackRepository = ItrackRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await trackRepository.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Track track = await trackRepository.GetByIdAsync(id);
            if (track == null)
            {
                return Problem("Id non pr�sent en base");
            }
            else
            {
                return Ok(track);
            }
        }
        [HttpGet("Search/{therme}")]
        public async Task<IActionResult> Search(string therme)
        {
            return Ok(await trackRepository.SearchAsync(therme));
        }
        [HttpPost()]
        public async Task<IActionResult> Post(Track track)
        {
            return Ok(await trackRepository.Post(track));
        }
        [HttpPut]
        public async Task<IActionResult> Put(Track track)
        {
            return Ok(await trackRepository.Put(track));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            try
            {
                await trackRepository.DeleteAsync(id);
            }
            catch
            {
                return Problem("id inconnu en base");
            }
            return Ok("Deletion successful");
        }
        [HttpPatch("{id}/Title/{title}")]
        public async Task<IActionResult> PatchTitle(int id, string title) 
        {
            Track track = await trackRepository.GetByIdAsync(id);
            track.Title = title;
            return Ok(await trackRepository.PatchTitle(track));
        }

        [HttpPatch("{id}/Artist/{artist}")]
        public async Task<IActionResult> PatchArtist(int id, string artist)
        {
            Track track = await trackRepository.GetByIdAsync(id);
            track.ArtistName = artist;
            return Ok(await trackRepository.PatchArtist(track));
        }
        [HttpPatch("{id}/Duration/{duration}")]
        public async Task<IActionResult> PatchDuration(int id, int duration)
        {
            Track track = await trackRepository.GetByIdAsync(id);
            track.DurationInSecond = duration;
            return Ok(await trackRepository.PatchDuration(track));
        }
    }

}
