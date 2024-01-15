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

        [HttpGet(Name = "GetTrack")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await trackRepository.GetAllAsync());
        }
        [HttpGet("GetTrackById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await trackRepository.GetByIdAsync(id));
        }
        [HttpGet("Search/{therme}")]
        public async Task<IActionResult> Search(string therme)
        {
            return Ok(await trackRepository.SearchAsync(therme));
        }
        [HttpPost("Title/{title}/Artist/{artist}/Duration/{duration}")]
        public async Task<IActionResult> Post(string title, string artist, int duration)
        {
            Track track = new() {Title = title, ArtistName = artist, DurationInSecond = duration };
            return Ok(await trackRepository.Post(track));
        }
        [HttpPut("Put/{id}/Title/{title}/Artist/{artist}/Duration/{duration}")]
        public async Task<IActionResult> Put(int id, string title, string artist, int duration) {
            Track track = await trackRepository.GetByIdAsync(id);
            track.Title = title;
            track.ArtistName = artist;
            track.DurationInSecond = duration;
            return Ok(await trackRepository.Put(track));
        }
    }
}
