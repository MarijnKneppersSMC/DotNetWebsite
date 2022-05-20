using DotNetWebsite.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetWebsite.Pages.Movie
{
    public class IndexModel : PageModel
    {
        private DatabaseContext _context;

        private string searchString = "";

        [BindProperty]
        public string SearchString { get { return searchString; } set
            {
                searchString = value;
            }
        }

        public List<Models.Movie> FilteredMovies => (!(String.IsNullOrEmpty(SearchString) || String.IsNullOrEmpty(SearchString)))? _context.Movies.Where(movie => movie.Title.ToLower().Contains(SearchString.ToLower())).ToList() : new List<Models.Movie>();

        public IndexModel(DatabaseContext context)
        {
            searchString = "";
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(string? searchString)
        {
            if (searchString != null)
            {
                SearchString = searchString;
            }

            return Page();
        }
    }
}
