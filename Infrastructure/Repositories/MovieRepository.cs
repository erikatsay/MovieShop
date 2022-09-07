using System.Collections;
using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using ApplicationCore.Models;
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

    public async Task<PagedResultSet<Movie>> GetMoviesByGenrePagination(int genreId, int pageSize = 30, int page = 1)
    {
        var totalMoviesConntOfGenre = await _movieShopDbContext.MovieGenres.Where(g => g.GenreId == genreId).CountAsync();
        if (totalMoviesConntOfGenre == 0)
        {
            throw new Exception("No Movies found for this genre");
        }

        var movies = await _movieShopDbContext.MovieGenres.Where(g => g.GenreId == genreId).Include(g=>g.Movie)
            .OrderByDescending(m=>m.Movie.Revenue)
            .Select(m=>new Movie
            {
                Id = m.MovieId,
                PosterUrl = m.Movie.PosterUrl,
                Title = m.Movie.Title
            })
            .Skip((page-1)*pageSize).Take(pageSize).ToListAsync();

        var pagedMovies = new PagedResultSet<Movie>(movies, page, pageSize, totalMoviesConntOfGenre);
        return pagedMovies;
    }

    public async Task<List<Movie>> GetTop30GrossingMovies()
    {
        // call the database
        var movies = await _movieShopDbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
        return movies;

    }
}
