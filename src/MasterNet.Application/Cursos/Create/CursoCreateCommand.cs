using MasterNet.Domain;
using MasterNet.Persistence;
using MediatR;

namespace MasterNet.Application.Cursos.CursosCreate;

public class CursosCreateCommand
{
    public record CursoCreateCommandRequest(CursoCreateRequest CursoCreateRequest) : IRequest<Guid>;

    internal class CursosCreateCommandHandler : IRequestHandler<CursoCreateCommandRequest, Guid>
    {
        private readonly MasterNetDbContext _context;

        public CursosCreateCommandHandler(MasterNetDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CursoCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var curso = new Curso(){
                Id = Guid.NewGuid(),
                Titulo = request.CursoCreateRequest.Titulo,
                Descripcion = request.CursoCreateRequest.Descripcion,
                FechaPublicacion = DateTime.Now

            };

            _context.Add(curso);
            await _context.SaveChangesAsync();

            return curso.Id;
        }
    }
}