using blanchard_web_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace blanchard_web_api
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions){ }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Artist> Artists { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Artist> artists = new() {
                new Artist {Id = 1, Name = "David Bowie"},
                new Artist {Id = 2, Name = "Manau"},
                new Artist {Id = 3, Name = "Jean-Jacques Goldman"},
                new Artist {Id = 4, Name = "Indochine" },
                new Artist {Id = 5, Name = "Florian Montagne"}
            };

            List<Track> tracks = new() {
                new Track { Id = 1, Title = "Life On Mars?", ArtistName="David Bowie", DurationInSecond=202, ArtistId=1},
                new Track { Id = 2, Title = "La tribu de Dana", ArtistName="Manau", DurationInSecond=285, ArtistId=2},
                new Track { Id = 3, Title = "Au bout de mes rêves", ArtistName="Jean-Jacques Goldman", DurationInSecond=237, ArtistId=3},
                new Track { Id = 4, Title = "La vie est belle", ArtistName="Indochine", DurationInSecond=326,ArtistId=4},
                new Track { Id = 5, Title = "Moi, je viens de Narbonne", ArtistName="Florian Montagne", DurationInSecond=122,ArtistId=5},
                new Track { Id = 6, Title = "J'ai demandé à la lune", ArtistName="Indochine", DurationInSecond=300, ArtistId=4}
           };

            modelBuilder.Entity<Artist>().HasData(artists);
            modelBuilder.Entity<Track>().HasData(tracks);
            base.OnModelCreating(modelBuilder);
        }

    }
}
