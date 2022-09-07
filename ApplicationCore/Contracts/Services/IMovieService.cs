using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IMovieService
{
        Task< List<MovieCardModel> > GetTop30GrossingMovies();
        Task<MovieDetailsModel> GetMovieDetails(int movieId);
        Task<PagedResultSet<MovieCardModel>> GetMoviesByPagination(int genredId, int pageSize = 30, int page = 1);
}