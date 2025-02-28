using System.Runtime.InteropServices;
using Bogus.DataSets;
using MasterNet.Application.Core;
using MasterNet.Application.Cursos.CursosCreate;
using MasterNet.Application.Cursos.GetCursos;
using MasterNet.Application.Cursos.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static MasterNet.Application.Cursos.CursoReporteExcel.CursoReporteExcelQuery;
using static MasterNet.Application.Cursos.CursosCreate.CursosCreateCommand;
using static MasterNet.Application.Cursos.Delete.CursoDeleteCommand;
using static MasterNet.Application.Cursos.GetCurso.GetCursoQuery;
using static MasterNet.Application.Cursos.GetCursos.GetCursosQuery;
using static MasterNet.Application.Cursos.Update.CursoUpdateCommand;

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
    public async Task<ActionResult<Result<Guid>>> CursoCreate([FromForm] CursoCreateRequest request, CancellationToken cancellationToken)
    {
        var command = new CursoCreateCommandRequest(request);
        return await _sender.Send(command, cancellationToken);

    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Result<Guid>>> CursoUpdate([FromBody] CursoUpdateRequest request, Guid id, CancellationToken cancellationToken)
    {
        var command = new CursoUpdateCommandRequest(request, id);
        var resultado = await _sender.Send(command, cancellationToken);

        return resultado.IsSuccess ? Ok(resultado.Value) : BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Unit>> CursoDelete(Guid id, CancellationToken cancellationToken)
    {
        var command = new CursoDeleteCommandRequest(id);
        var resultado = await _sender.Send(command, cancellationToken);
        return resultado.IsSuccess ? Ok(resultado.Value) : BadRequest();
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