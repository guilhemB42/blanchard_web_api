using blanchard_web_api.Entities;

namespace blanchard_web_api
{
    public interface ITrackRepository
    {
        Task<List<Track>> GetAllAsync();
        Task<Track> GetByIdAsync(int id);
        Task<List<Track>> SearchAsync(string  searchTerm);
        Task<Track> Post(Track track);
        Task<Track> Put(Track track);
        Task<Track> PatchTitle(Track track);
        Task<Track> PatchArtist(Track track);
        Task<Track> PatchDuration(Track track); 
        Task DeleteAsync(int id);

    }
}
