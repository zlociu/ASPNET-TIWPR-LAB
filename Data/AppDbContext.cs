using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zajecia_ASPNET.Models;

namespace Zajecia_ASPNET.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) 
        { 

        }

        public DbSet<BookModel> Books { get; set; }

    }
}
