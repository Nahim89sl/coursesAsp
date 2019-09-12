using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SuperRazor.Models
{
    public class SuperRazorContext : DbContext
    {
        public SuperRazorContext (DbContextOptions<SuperRazorContext> options)
            : base(options)
        {
        }

        public DbSet<SuperRazor.Models.Movie> Movie { get; set; }
    }
}
