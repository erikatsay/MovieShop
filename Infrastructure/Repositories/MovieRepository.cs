using System.Collections;
using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Intrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Intrastructure.Repository;

public class MovieRepository : IMovieRepository
{
    private readonly MovieShopDbContext _movieShopDbContext;

    public MovieRepository(MovieShopDbContext movieShopDbContext)
    {
        _movieShopDbContext = movieShopDbContext;
    }

    public async Task<Movie> GetById(int id)
    {
        var movieDetails = await _movieShopDbContext.Movies
            .Include(m => m.GenresOfMovie).ThenInclude((m => m.Genre))
            .Include(m => m.CastsOfMovie).ThenInclude(m => m.Cast)
            .Include(m=>m.Trailers)
            .FirstOrDefaultAsync(m=>m.Id == id);
        
        return movieDetails;
    }

    public async Task<List<Movie>> GetTop30GrossingMovies()
    {
        // call the database
        var movies = await _movieShopDbContext.Movies.OrderBy(m => m.Revenue).Take(30).ToListAsync();
        return movies;

    }
}
