using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Intrastructure.Services;

public class CastService : ICastService
{
    private readonly ICastRepository _castRepository;

    public CastService(ICastRepository castRepository)
    {
        _castRepository = castRepository;
    }

    public async Task<CastDetailsModel> GetCastDetails(int castId)
    {
        var castDetails = await _castRepository.GetById(castId);

        var castDetailModel = new CastDetailsModel
        {
            Id = castDetails.Id,
            Gender = castDetails.Gender,
            Name = castDetails.Name,
            ProfilePath = castDetails.ProfilePath,
            TmdbUrl = castDetails.TmdbUrl
        };
        
        foreach (var movie in castDetails.MoviesOfCast)
        {
            castDetailModel.Movies.Add(new MovieCardModel
            {
                Id = movie.MovieId,
                Title = movie.Movie.Title,
                PosterUrl = movie.Movie.PosterUrl
            });
        }
        

        return castDetailModel;
    }
}