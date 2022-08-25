using System.Collections;
using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;

namespace Intrastructure.Repository;

public class MovieRepository: IMovieRepository
{
    public List<Movie> GetTop30GrossingMovies()
    {
        var movies = new List<Movie>
        {
            Capacity = 0
        };
        return movies;
    }

    public List<Movie> GetTopGrossingMovies()
    {
        throw new NotImplementedException();
    }
}