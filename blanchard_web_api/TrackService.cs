
namespace blanchard_web_api
{
    public class TrackService : ITrackService
    {
        ITrackRepository trackRepository;

        public TrackService(ITrackRepository ItrackRepository) {
            trackRepository = ItrackRepository;
        }
        public Task DeleteAsync(int id)
        {
            return trackRepository.DeleteAsync(id);
        }

        public Task<List<Track>> GetAllAsync()
        {
            return trackRepository.GetAllAsync();
        }

        public Task<Track> GetByIdAsync(int id)
        {
            return trackRepository.GetByIdAsync(id);
        }

        public Task<Track> PatchArtist(Track track)
        {
            return trackRepository.PatchArtist(track);
        }

        public Task<Track> PatchDuration(Track track)
        {
            return trackRepository.PatchDuration(track);
        }

        public Task<Track> PatchTitle(Track track)
        {
            return trackRepository.PatchTitle(track);
        }

        public Task<Track> Post(Track track)
        {
            return trackRepository.Post(track);
        }

        public Task<Track> Put(Track track)
        {
            return trackRepository.Put(track);
        }

        public Task<List<Track>> SearchAsync(string searchTerm)
        {
            return trackRepository.SearchAsync(searchTerm);
        }
    }
}
