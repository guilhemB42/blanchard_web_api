namespace blanchard_web_api.Entities
{
    public class Artist
    {
        public int Id { get; set; }

        public String? Name { get; set; }

        public List<Track>? Tracks { get; set; }
    }
}
