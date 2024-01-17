using blanchard_web_api.Entities;
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

        public async Task<Track> PatchDuration(Track track)
        {
            Track trackToEdit = trackContext.Tracks.Find(track.Id);
            trackToEdit.DurationInSecond = track.DurationInSecond;
            await trackContext.SaveChangesAsync();
            return track;
        }

        public async Task<Track> PatchTitle(Track track)
        {
            Track trackToEdit = trackContext.Tracks.Find(track.Id);
            trackToEdit.Title = track.Title;
            await trackContext.SaveChangesAsync();
            return track;
        }

        public async Task<Track> PatchArtist(Track track)
        {
            Track trackToEdit = trackContext.Tracks.Find(track.Id);
            trackToEdit.ArtistName = track.ArtistName;
            await trackContext.SaveChangesAsync();
            return track;
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

        public async Task<List<Track>> SearchAsync(string searchTerm)
        {
            return await trackContext.Tracks.Where(
                t =>
                t.Title.Contains(searchTerm)
                || t.ArtistName.Contains(searchTerm)
                ).ToListAsync();
        }
    }
}
