using DotNetWebsite.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetWebsite.Pages.Movie
{
    public class MovieModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private Models.Movie? _movie;
        public Models.Movie Movie
        {
            get
            {
                if (_movie == null)
                {
                    throw new NullReferenceException("No movie has been retrieved yet");
                }
                return _movie;
            }
            set
            {
                _movie = value;
            }
        }

        public MovieModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(int ID)
        {
            Movie = MovieContext.Instance.GetMovie(ID);
        }
    }
}
