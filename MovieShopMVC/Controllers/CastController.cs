using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers;

public class CastController : Controller
{
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        throw new NotImplementedException();
        /*var movieDetails =  await _castService.GetMovieDetails(id);
        return View(castDetails);*/
    }
}