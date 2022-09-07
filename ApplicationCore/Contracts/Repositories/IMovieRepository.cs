using System.Collections;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repository;

public interface IMovieRepository
{
    //Get top 30 movies from database
    Task< List<Movie> > GetTop30GrossingMovies(); 
    Task< Movie > GetById(int movieId);

    Task<PagedResultSet<Movie>> GetMoviesByGenrePagination(int genreId, int pageSize = 30, int page = 1);
}