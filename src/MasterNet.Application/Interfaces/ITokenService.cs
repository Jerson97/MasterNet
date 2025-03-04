using MasterNet.Persistence.Models;

namespace MasterNet.Application.Interface;

public interface ITokenService
{
    Task<string> CreateToken(AppUser user);
}