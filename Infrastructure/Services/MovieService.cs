using System.Runtime.CompilerServices;
using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Intrastructure.Migrations;
using Intrastructure.Repository;

namespace Intrastructure.Services;

public class MovieService: IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    
    public async Task< List<MovieCardModel> > GetTop30GrossingMovies()
    {
        var movies = await  _movieRepository.GetTop30GrossingMovies();

        var movieCards = new List<MovieCardModel>();
        foreach (var movie in movies)
        {
            movieCards.Add(new MovieCardModel { Id = movie.Id, Title = movie.Title, PosterUrl = movie.PosterUrl });
        }

        return movieCards;
    }

    public async Task<MovieDetailsModel> GetMovieDetails(int movieId)
    {
        var movieDetails = await _movieRepository.GetById(movieId);
        
        var movieDetailsModel = new MovieDetailsModel
        {
            Id = movieDetails.Id,
            Title = movieDetails.Title,
            PosterUrl = movieDetails.PosterUrl,
            BackdropUrl = movieDetails.BackdropUrl,
            OriginalLanguage = movieDetails.OriginalLanguage,
            Overview = movieDetails.Overview,
            Budget = movieDetails.Budget,
            ReleaseDate = movieDetails.ReleaseDate,
            Revenue = movieDetails.Revenue,
            ImdbUrl = movieDetails.ImdbUrl,
            TmdbUrl = movieDetails.TmdbUrl,
            RunTime = movieDetails.RunTime,
            Tagline = movieDetails.Tagline,
            Price = movieDetails.Price
        };

        foreach (var trailer in movieDetails.Trailers)
        {
            movieDetailsModel.Trailers.Add(new TrailerModel
            {
                TrailerUrl = trailer.TrailerUrl,
                Name = trailer.Name
            });
        }
        
        foreach (var cast in movieDetails.CastsOfMovie)
        {
            movieDetailsModel.Casts.Add(new CastModel
            {
                Id = cast.CastId, Name = cast.Cast.Name, Character = cast.Character, ProfilePath = cast.Cast.ProfilePath
            });
        }
        
        foreach (var genre in movieDetails.GenresOfMovie)
        {
            movieDetailsModel.Genres.Add(new GenreModel
            {
                Id = genre.GenreId, Name = genre.Genre.Name
            });
        }

        return movieDetailsModel;
    }
}