using blanchard_web_api.Entities;

namespace blanchard_web_api
{
    public class ArtistRepository : IArtistRepository
    {
        Context artistContext;

        public ArtistRepository(Context context)
        {
            artistContext = context;
        }
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Artist>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Artist> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Artist> Post(Artist artist)
        {
            throw new NotImplementedException();
        }

        public Task<Artist> Put(Artist artist)
        {
            throw new NotImplementedException();
        }

        public Task<List<Artist>> SearchAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
