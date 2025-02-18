using AutoMapper;
using AutoMapper.QueryableExtensions;
using MasterNet.Application.Calificaiones.GetCalificaciones;
using MasterNet.Application.Core;
using MasterNet.Application.Instructores.GetInstructores;
using MasterNet.Application.Photos.GetPhoto;
using MasterNet.Application.Precios.GetPrecios;
using MasterNet.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MasterNet.Application.Cursos.GetCurso;

public class GetCursoQuery
{
    public record GetCursoQueryRequest : IRequest<Result<CursoDto>>
    {
        public Guid Id { get; set; }
    }

    internal class GetCursoQueryHandler : IRequestHandler<GetCursoQueryRequest, Result<CursoDto>>
    {
        private readonly MasterNetDbContext _context;
        private readonly IMapper _mapper;

        public GetCursoQueryHandler(MasterNetDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<CursoDto>> Handle(GetCursoQueryRequest request, CancellationToken cancellationToken)
        {
            var curso = await _context.Cursos!.Where(x => x.Id == request.Id)
                        .Include(x => x.Instructores)
                        .Include(x => x.Precios)
                        .Include(x => x.Calificaciones)
                        .ProjectTo<CursoDto>(_mapper.ConfigurationProvider)
                        .FirstOrDefaultAsync();

            return Result<CursoDto>.Success(curso!);
        }
    }
}

public record CursoDto(
    Guid Id,
    string Titulo,
    string Descripcion,
    DateTime? FechaPublicacion,
    List<InstructorDto> Instructores,
    List<CalificacionDto> Calificaciones,
    List<PrecioDto> Precios,
    List<PhotoDto> Photos
);
