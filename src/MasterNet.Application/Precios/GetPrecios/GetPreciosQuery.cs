using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MasterNet.Application.Core;
using MasterNet.Domain;
using MasterNet.Persistence;
using MediatR;

namespace MasterNet.Application.Precios.GetPrecios;

public class GetPreciosQuery
{

    public record GetPreciosQueryRequest 
    : IRequest<Result<PagedList<PrecioDto>>>
    {
        public GetPreciosRequest? PreciosRequest {get;set;} 
    }

    internal class GetPreciosQueryHandler :
    IRequestHandler<GetPreciosQueryRequest, Result<PagedList<PrecioDto>>>
    {
        private readonly MasterNetDbContext _context;
        private readonly IMapper _mapper;

        public GetPreciosQueryHandler(MasterNetDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<PrecioDto>>> Handle(
            GetPreciosQueryRequest request, 
            CancellationToken cancellationToken
        )
        {
        
            IQueryable<Precio> queryable = _context.Precios!;

            var predicate = ExpressionBuilder.New<Precio>();

            if(!string.IsNullOrEmpty(request.PreciosRequest!.Nombre))
            {   
                predicate  = predicate
                .And(y => y.Nombre!.Contains(request.PreciosRequest!.Nombre));
            }

            if(!string.IsNullOrEmpty(request.PreciosRequest!.OrderBy))
            {
                Expression<Func<Precio, object>>? orderSelector = 
                    request.PreciosRequest.OrderBy.ToLower() switch
                    {
                        "nombre" => x => x.Nombre!,
                        "precio" => x => x.PrecioActual,
                        _ =>x => x.Nombre!
                    };

                    bool orderBy = request.PreciosRequest.OrderAsc.HasValue
                        ? request.PreciosRequest.OrderAsc.Value
                        : true;
                    
                    queryable = orderBy
                                ? queryable.OrderBy(orderSelector)
                                : queryable.OrderByDescending(orderSelector);
            }

            queryable = queryable.Where(predicate);

            var preciosQuery = queryable
                    .ProjectTo<PrecioDto>(_mapper.ConfigurationProvider)
                    .AsQueryable();
           

           var pagination = await PagedList<PrecioDto>
            .CreateAsync(preciosQuery, 
                request.PreciosRequest.PageNumber, 
                request.PreciosRequest.PageSize
           );

           return Result<PagedList<PrecioDto>>.Success(pagination);
        }
    }
}


public record PrecioDto(
    Guid? Id,
    string? Nombre,
    decimal? PrecioActual,
    decimal? PrecioPromocion
)
{
    public PrecioDto(): this(null, null, null, null)
    {
    }
}