using blanchard_web_api.Entities;

namespace blanchard_web_api
{
    public interface IArtistRepository
    {
        Task<List<Artist>> GetAllAsync();
        Task<Artist> GetByIdAsync(int id);
        Task<List<Artist>> SearchAsync(string searchTerm);
        Task<Artist> Post(Artist artist);
        Task<Artist> Put(Artist artist);
        Task DeleteAsync(int id);
    }
}
