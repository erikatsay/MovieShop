using System.Security.Claims;

namespace MovieShopMVC.Infra;

public class CurrentUser: ICurrentUser
{
    private readonly IHttpContextAccessor _contextAccessor;

    public CurrentUser(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public int UserId => Convert.ToInt32(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
    public bool IsAdmin { get; }
    public bool IsAuthenticated => _contextAccessor.HttpContext.User.Identity.IsAuthenticated;

    public string Email => _contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
    public string ProfilePictureUrl { get; }

    public string FallName =>
        _contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName).Value + ' ' +
        _contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname).Value;
}