using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DotNetWebsite.Data;
using Microsoft.AspNetCore.Authorization;

namespace DotNetWebsite.Pages.Movie.Manage
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly DatabaseContext _context;

        public IndexModel(DatabaseContext context)
        {
            _context = context;
        }

        public IList<Models.Movie> Movie { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Movies != null)
            {
                Movie = await _context.Movies.ToListAsync();
            }
        }
    }
}
