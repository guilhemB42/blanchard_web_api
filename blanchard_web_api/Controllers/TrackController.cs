using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace blanchard_web_api.Controllers
{
    [ApiController]
    [Tags("Music database API")]
    [Route("api/[controller]")]
    public class TrackController : ControllerBase
    {
        ITrackService trackService;
        IMapper mapper;
        private readonly ILogger<TrackController> _logger;

        public TrackController(ILogger<TrackController> logger, ITrackService ItrackRepository, IMapper Imapper)
        {
            trackService = ItrackRepository;
            mapper = Imapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await trackService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Track track = await trackService.GetByIdAsync(id);
            if (track == null)
            {
                return Problem("Id non présent en base");
            }
            else
            {
                return Ok(track);
            }
        }
        [HttpGet("Search/{therme}")]
        public async Task<IActionResult> Search(string therme)
        {
            return Ok(await trackService.SearchAsync(therme));
        }
        [HttpPost()]
        public async Task<IActionResult> Post(TrackDTO dto_track)
        {
            Track track = mapper.Map<Track>(dto_track);
            return Ok(await trackService.Post(track));
        }
        [HttpPut]
        public async Task<IActionResult> Put(Track track)
        {
            Track trackDBB = await trackService.GetByIdAsync(track.Id);
            if (trackDBB == null) {
                return Problem("id inconnu, MAJ impossible");
            }
            else
            {
                return Ok(await trackService.Put(track));

            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            try
            {
                await trackService.DeleteAsync(id);
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
            Track track = await trackService.GetByIdAsync(id);
            if (track == null)
            {
                return Problem("id inconnu en bdd, patch impossible");
            }
            else
            {
                track.Title = title;
                return Ok(await trackService.PatchTitle(track));
            }
        }

        [HttpPatch("{id}/Artist/{artist}")]
        public async Task<IActionResult> PatchArtist(int id, string artist)
        {
            Track track = await trackService.GetByIdAsync(id);
            if(track==null){
                return Problem("id inconnu en bdd, patch impossible");
            }
            else{
                track.ArtistName = artist;
                return Ok(await trackService.PatchArtist(track));
            }
        }
        [HttpPatch("{id}/Duration/{duration}")]
        public async Task<IActionResult> PatchDuration(int id, int duration)
        {
            Track track = await trackService.GetByIdAsync(id);
            if(track==null){
                return Problem("id inconnu en bdd, patch impossible");
            }
            else{
                track.DurationInSecond = duration;
                return Ok(await trackService.PatchDuration(track));
            }
        }
    }

}
