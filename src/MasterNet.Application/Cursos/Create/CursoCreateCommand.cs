using MasterNet.Application.Core;
using MasterNet.Domain;
using MasterNet.Persistence;
using MediatR;

namespace MasterNet.Application.Cursos.CursosCreate;

public class CursosCreateCommand
{
    public record CursoCreateCommandRequest(CursoCreateRequest CursoCreateRequest) : IRequest<Result<Guid>>;

    internal class CursosCreateCommandHandler : IRequestHandler<CursoCreateCommandRequest, Result<Guid>>
    {
        private readonly MasterNetDbContext _context;

        public CursosCreateCommandHandler(MasterNetDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Guid>> Handle(CursoCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var curso = new Curso(){
                Id = Guid.NewGuid(),
                Titulo = request.CursoCreateRequest.Titulo,
                Descripcion = request.CursoCreateRequest.Descripcion,
                FechaPublicacion = DateTime.Now

            };

            _context.Add(curso);

            var resultado = await _context.SaveChangesAsync() > 0;
            return resultado ? Result<Guid>.Success(curso.Id)
                             : Result<Guid>.Failure("No se pudo insertal el curso");
            return Result<Guid>.Success(curso.Id);
        }
    }
}