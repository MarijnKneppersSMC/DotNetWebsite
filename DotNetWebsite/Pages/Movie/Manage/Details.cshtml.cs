﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly DotNetWebsite.Data.DatabaseContext _context;

        public DetailsModel(DotNetWebsite.Data.DatabaseContext context)
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