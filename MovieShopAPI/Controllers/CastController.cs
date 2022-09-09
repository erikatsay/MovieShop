using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class CastController : ControllerBase
    {
        private readonly ICastService _castService;

        public CastController(ICastService castService)
        {
            _castService = castService;
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCast( int id)
        {
            var cast = await _castService.GetCastDetails(id);
            if (cast == null )
            {
                return NotFound(new { errorMessage = $"No Movie Found for {id}"});
            }

            return Ok(cast);
        }
    }
}
