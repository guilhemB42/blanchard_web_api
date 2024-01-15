using Microsoft.EntityFrameworkCore;

namespace blanchard_web_api
{
    public class TrackRepository : ITrackRepository
    {
        Context trackContext;

        public TrackRepository(Context context) { 
            trackContext = context;
        }
        public async Task DeleteAsync(int id)
        {
            Track trackToDelete = await trackContext.Tracks.FirstOrDefaultAsync(t => t.Id == id);
            trackContext.Tracks.Remove(trackToDelete);
            await trackContext.SaveChangesAsync();
        }

        public async Task<List<Track>> GetAllAsync()
        {
            return await trackContext.Tracks.ToListAsync();
        }

        public async Task<Track> GetByIdAsync(int id)
        {
            return await trackContext.Tracks.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Track> Post(Track track)
        {
            trackContext.Tracks.Add(track);
            await trackContext.SaveChangesAsync();
            return track;
        }

        public async Task<Track> Put(Track track)
        {
            Track trackToEdit = trackContext.Tracks.Find(track.Id);
            trackToEdit.Title = track.Title;
            trackToEdit.ArtistName = track.ArtistName;
            trackToEdit.DurationInSecond = track.DurationInSecond;
            await trackContext.SaveChangesAsync();
            return track;
        }

        public Task<List<Track>> SearchAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
