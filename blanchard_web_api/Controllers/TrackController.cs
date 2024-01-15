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
        public IActionResult Get()
        {
            return Ok(trackRepository.GetAllAsync());           
        }
    }
}
