namespace blanchard_web_api
{
    public interface ITrackRepository
    {
        Task<List<Track>> GetAllAsync();
        Task<Track> GetByIdAsync(int id);
        Task<List<Track>> SearchAsync(string  searchTerm);
        Task<Track> Post(Track track);
        Task<Track> Put(Track track);
        Task DeleteAsync(int id);

    }
}
