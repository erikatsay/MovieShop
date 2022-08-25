using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Intrastructure.Data;

public class MovieShopDbContext: DbContext
{
    public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
    {
        
    }

    public DbSet<Movie> Movies { get; set; }

}