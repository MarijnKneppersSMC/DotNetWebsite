namespace DotNetWebsite.Models
{
    public class Movie
    {
        public int Id { get; set; } = -1;
        public string Title { get; set; } = "Title not available";
        public string Synopsis { get; set; } = "Synopsis not available";
        public string Director { get; set; } = "Director not available";
        public int Year { get; set; } = -1;
        public int Length { get; set; } = -1;
        public string Poster { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/65/No-Image-Placeholder.svg/1665px-No-Image-Placeholder.svg.png";

    }
}
