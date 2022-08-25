using System.Collections;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repository;

public interface IMovieRepository
{
    //Get top 30 movies from database
    List<Movie> GetTop30GrossingMovies();
}