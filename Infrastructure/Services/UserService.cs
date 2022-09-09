using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Intrastructure.Services;

public class UserService:IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public Task<User> GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task PurchaseMovie(PurchaseRequestModel purchaseRequest, int userId)
    {
        throw new NotImplementedException();
    }

    public Task IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId)
    {
        throw new NotImplementedException();
    }

    public Task GetAllPurchasesForUser(int id)
    {
        throw new NotImplementedException();
    }

    public Task GetPurchasesDetails(int userId, int movieId)
    {
        throw new NotImplementedException();
    }

    public Task AddFavorite(FavoriteRequestModel favoriteRequest)
    {
        throw new NotImplementedException();
    }

    public Task RemoveFavorite(FavoriteRequestModel favoriteRequest)
    {
        throw new NotImplementedException();
        /*_dbContext.Set<T>().Remove(entity);
        await _adContext.SaveChangesAsync();
        return entity;*/
    }

    public Task FavoriteExists(int id, int movieId)
    {
        throw new NotImplementedException();
    }

    public Task GetAllFavoritesForUser(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddMovieReview(ReviewRequestModel reviewRequest)
    {
        throw new NotImplementedException();
    }

    public Task UpdateMovieReview(ReviewRequestModel reviewRequest)
    {
        /*_adContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync()
        return entity;*/
        throw new NotImplementedException();
    }

    public Task DeleteMovieReview(int userId, int movieId)
    {
        throw new NotImplementedException();
    }

    public Task GetAllReviewsByUser(int id)
    {
        throw new NotImplementedException();
    }
}