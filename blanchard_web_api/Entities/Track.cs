using System.ComponentModel.DataAnnotations.Schema;

namespace blanchard_web_api.Entities
{
    public class Track
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ArtistName { get; set; }
        public int DurationInSecond { get; set; }
        [ForeignKey("Artist")]
        public int ArtistId { get; set; }
        public Artist? Artist { get; set; }
    }
}
