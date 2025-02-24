using MasterNet.Application.Calificaciones.GetCalificaciones;
using MasterNet.Application.Instructores.GetInstructores;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static MasterNet.Application.Calificaciones.GetCalificaciones.GetCalificacionesQuery;
using static MasterNet.Application.Instructores.GetInstructores.GetInstructoresQuery;

namespace MasterNet.WebApi.Controllers;

[ApiController]
[Route("api/calificaciones")]
public class CalificacionesController : ControllerBase
{
    private readonly ISender _sender;
    public CalificacionesController(ISender sender)
    {
        _sender = sender;
    }

    public async Task<ActionResult> PaginationCalificacion([FromQuery] GetCalificacionesRequest request, CancellationToken cancellationToken)
    {
        var query = new GetCalificacionesQueryRequest {
            CalificacionesRequest = request
        };
        var resultados = await _sender.Send(query, cancellationToken);
        return resultados.IsSuccess ? Ok(resultados) : NotFound();
    }    


}