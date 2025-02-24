using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MasterNet.Application.Core;
using MasterNet.Domain;
using MasterNet.Persistence;
using MediatR;

namespace MasterNet.Application.Calificaciones.GetCalificaciones;

public class GetCalificacionesQuery
{

    public record GetCalificacionesQueryRequest 
    :IRequest<Result<PagedList<CalificacionDto>>>
    {
        public GetCalificacionesRequest? CalificacionesRequest {get;set;}
    }

    internal class GetCalificacionesQueryHandler
    : IRequestHandler<GetCalificacionesQueryRequest, Result<PagedList<CalificacionDto>>>
    {
        private readonly MasterNetDbContext _context;
        private readonly IMapper _mapper;

        public GetCalificacionesQueryHandler(MasterNetDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<CalificacionDto>>> Handle(GetCalificacionesQueryRequest request, CancellationToken cancellationToken)
        {
            
            IQueryable<Calificacion> queryable = _context.Calificacion!;
            

            var predicate = ExpressionBuilder.New<Calificacion>();
            if(!string.IsNullOrEmpty(request.CalificacionesRequest!.Alumno))
            {
                predicate = predicate
                .And(y => y.Alumno!.Contains(request.CalificacionesRequest.Alumno));
            }

            if(request.CalificacionesRequest.CursoId is not null)
            {
                predicate = predicate
                .And(y => y.CursoId== request.CalificacionesRequest.CursoId);
            }

            if(!string.IsNullOrEmpty(request.CalificacionesRequest.OrderBy))
            {
                Expression<Func<Calificacion, object>>? orderBySelector =
                    request.CalificacionesRequest.OrderBy.ToLower() switch
                    {
                        "alumno" => x => x.Alumno!,
                        "curso" => x => x.CursoId!,
                        _ => x => x.Alumno!
                    };

                    bool orderBy = request.CalificacionesRequest.OrderAsc.HasValue
                                    ? request.CalificacionesRequest.OrderAsc.Value
                                    : true;

                    queryable = orderBy 
                                ? queryable.OrderBy(orderBySelector)
                                : queryable.OrderByDescending(orderBySelector);
            }

            queryable = queryable.Where(predicate);

            var calificacionQuery = queryable
                                    .ProjectTo<CalificacionDto>(_mapper.ConfigurationProvider)
                                    .AsQueryable();

            var pagination = await PagedList<CalificacionDto>
                    .CreateAsync(
                        calificacionQuery,
                        request.CalificacionesRequest.PageNumber,
                        request.CalificacionesRequest.PageSize
                    );


            return Result<PagedList<CalificacionDto>>.Success(pagination);
        }
    }

}






public record CalificacionDto(
    string? Alumno,
    int? Puntaje,
    string? Comentario,
    string? NombreCurso
)
{
    public CalificacionDto(): this(null, null, null, null)
    {
    }
}