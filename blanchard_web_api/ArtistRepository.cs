using blanchard_web_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace blanchard_web_api
{
    public class ArtistRepository : IArtistRepository
    {
        Context artistContext;

        public ArtistRepository(Context context)
        {
            artistContext = context;
        }
        public async Task DeleteByIdAsync(int id)
        {
            Artist artistToDelete = await artistContext.Artists.FirstOrDefaultAsync(a => a.Id == id);
            artistContext.Artists.Remove(artistToDelete);
            await artistContext.SaveChangesAsync();
        }

        public async Task<List<Artist>> GetAllAsync()
        {
            return await artistContext.Artists.ToListAsync();
        }

        public async Task<Artist> GetByIdAsync(int id)
        {
            return await artistContext.Artists.Include(a => a.Tracks).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Artist> Post(Artist artist)
        {
            artistContext.Artists.Add(artist);
            await artistContext.SaveChangesAsync();
            return artist;
        }

        public async Task<Artist> Put(Artist artist)
        {
            Artist artistToEdit = artistContext.Artists.Find(artist.Id);
            artistToEdit.Name = artist.Name;
            await artistContext.SaveChangesAsync();
            return artist;
        }

        public async Task<List<Artist>> SearchAsync(string searchTerm)
        {
            return await artistContext.Artists.Where(
              a=>
              a.Name.Contains(searchTerm)
              ).ToListAsync();
        }
    }
}
