using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SuperRazor.Models;

namespace SuperRazor.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly SuperRazor.Models.SuperRazorContext _context;

        public IndexModel(SuperRazor.Models.SuperRazorContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
