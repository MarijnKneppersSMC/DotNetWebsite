using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DotNetWebsite.Data;
using Microsoft.AspNetCore.Authorization;

namespace DotNetWebsite.Pages.Movie.Manage
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly DatabaseContext _context;

        public DetailsModel(DatabaseContext context)
        {
            _context = context;
        }

        public Models.Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                Movie = movie;
            }
            return Page();
        }
    }
}
