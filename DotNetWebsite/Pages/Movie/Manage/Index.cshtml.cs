using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DotNetWebsite.Data;
using DotNetWebsite.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace DotNetWebsite.Pages.Movie.Manage
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly DotNetWebsite.Data.DatabaseContext _context;

        public IndexModel(DotNetWebsite.Data.DatabaseContext context)
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
