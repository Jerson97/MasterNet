using System.Net;
using MasterNet.Application.Core;
using MasterNet.Application.Precios.GetPrecios;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MasterNet.Application.Precios.GetPrecios.GetPreciosQuery;

namespace MasterNet.WebApi.Controllers;

[ApiController]
[Route("api/precios")]
public class PreciosController : ControllerBase
{
    private readonly ISender _sender;
    public PreciosController(ISender sender)
    {
        _sender = sender;
    }

    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<PagedList<PrecioDto>>> PaginationPrecios([FromQuery] GetPreciosRequest request, CancellationToken cancellationToken)
    {
        var query = new GetPreciosQueryRequest {
            PreciosRequest = request
        };
        var resultados = await _sender.Send(query, cancellationToken);
        return resultados.IsSuccess ? Ok(resultados.Value) : NotFound();
    }    


}