using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Intrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Intrastructure.Repository;

public class CastRepository: ICastRepository
{
    private readonly MovieShopDbContext _movieShopDbContext;
    
    public CastRepository(MovieShopDbContext movieShopDbContext)
    {
        _movieShopDbContext = movieShopDbContext;
    }
    
    public async Task<Cast> GetById(int id)
    {
        var castDetails = await _movieShopDbContext.Casts
            .Include(m=>m.MoviesOfCast).ThenInclude(m=>m.Movie)
            .FirstOrDefaultAsync(m=>m.Id == id);
        
        return castDetails;
    }
}