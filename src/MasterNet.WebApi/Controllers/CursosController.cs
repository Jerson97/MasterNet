using Bogus.DataSets;
using MasterNet.Application.Core;
using MasterNet.Application.Cursos.CursosCreate;
using MasterNet.Application.Cursos.GetCursos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static MasterNet.Application.Cursos.CursoReporteExcel.CursoReporteExcelQuery;
using static MasterNet.Application.Cursos.CursosCreate.CursosCreateCommand;
using static MasterNet.Application.Cursos.GetCurso.GetCursoQuery;
using static MasterNet.Application.Cursos.GetCursos.GetCursosQuery;

namespace MasterNet.WebApi.Controllers;

[ApiController]
[Route("api/cursos")]
public class CursosController : ControllerBase
{
    private readonly ISender _sender;

    [HttpGet]
    public async Task<ActionResult> PaginationCursos([FromQuery] GetCursosRequest request, CancellationToken cancellationToken)
    {
        var query = new GetCursosQueryRequest { CursosRequest= request};
        var resultado = await _sender.Send(query, cancellationToken);

        return resultado.IsSuccess ? Ok(resultado.Value) : NotFound();
    }
    public CursosController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("create")]
    public async Task<ActionResult<Result<Guid>>> CursoCreate([FromBody] CursoCreateRequest request, CancellationToken cancellationToken)
    {
        var command = new CursoCreateCommandRequest(request);
        return await _sender.Send(command, cancellationToken);

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> CursoGet(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetCursoQueryRequest {Id = id};
        var resultado = await _sender.Send(query, cancellationToken);

        return resultado.IsSuccess ? Ok(resultado.Value) : BadRequest();
    }

    [HttpGet("reporte")]
    public async Task<ActionResult> ReporteCSV(CancellationToken cancellationToken)
    {
        var query = new CursoReporteExcelQueryRequest();
        var resultado = await _sender.Send(query, cancellationToken);
        byte[] excelBytes = resultado.ToArray();
        return File(excelBytes, "text/csv", "cursos.csv");
    }
}