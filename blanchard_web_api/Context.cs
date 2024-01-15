using Microsoft.EntityFrameworkCore;

namespace blanchard_web_api
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions){ }
        public DbSet<Track> Tracks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Track> tracks = new() {
                new Track { Id = 1, Title = "Life On Mars?", ArtistName="David Bowie", DurationInSecond=202},
                new Track { Id = 2, Title = "La tribu de Dana", ArtistName="Manau", DurationInSecond=285},
                new Track { Id = 3, Title = "Au bout de mes rêves", ArtistName="Jean-Jacques Goldman", DurationInSecond=237},
                new Track { Id = 4, Title = "La vie est belle", ArtistName="Indochine", DurationInSecond=326},
                new Track { Id = 5, Title = "Moi, je viens de Narbonne", ArtistName="Florian Montagne", DurationInSecond=122}
           };

            modelBuilder.Entity<Track>().HasData(tracks);
            base.OnModelCreating(modelBuilder);
        }

    }
}
