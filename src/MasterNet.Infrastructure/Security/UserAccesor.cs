using System.Security.Claims;
using MasterNet.Application.Interface;
using Microsoft.AspNetCore.Http;

public class UserAccesor : IUserAccessor
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserAccesor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetUsername()
    {
        return _httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.Name)!;
    }
}
