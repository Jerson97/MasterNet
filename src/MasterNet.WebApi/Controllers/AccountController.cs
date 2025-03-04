using System.Net;
using MasterNet.Application.Accounts;
using MasterNet.Application.Accounts.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MasterNet.Application.Core.LoginCommand;

namespace MasterNet.WebApi.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController : ControllerBase
{
    private readonly ISender _sender;

    public AccountController(ISender sender)
    {
        _sender = sender;
    }
    
    [AllowAnonymous]
    [HttpPost("login")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<Profile>> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var command = new LoginCommandRequest(request);
        var resultado = await _sender.Send(command, cancellationToken);
        return resultado.IsSuccess ? Ok(resultado.Value) : Unauthorized();
    }
    
}