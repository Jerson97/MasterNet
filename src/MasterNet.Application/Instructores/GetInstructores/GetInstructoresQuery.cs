using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MasterNet.Application.Core;
using MasterNet.Domain;
using MasterNet.Persistence;
using MediatR;

namespace MasterNet.Application.Instructores.GetInstructores;

public class GetInstructoresQuery
{

    public record GetInstructoresQueryRequest
    : IRequest<Result<PagedList<InstructorDto>>>
    {
        public GetInstructoresRequest? InstructorRequest {get;set;}

    }


    internal class GetInstructoresQueryHandler
    : IRequestHandler<GetInstructoresQueryRequest, Result<PagedList<InstructorDto>>>
    {
        private readonly MasterNetDbContext _context;
        private readonly IMapper _mapper;

        public GetInstructoresQueryHandler(MasterNetDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<InstructorDto>>> Handle(
            GetInstructoresQueryRequest request, 
            CancellationToken cancellationToken
        )
        {
           
            IQueryable<Instructor> queryable = _context.Instructores!;

            var predicate = ExpressionBuilder.New<Instructor>();
            if(!string.IsNullOrEmpty(request.InstructorRequest!.Nombre))
            {
                predicate = predicate
                .And(y => y.Nombre!.Contains(request.InstructorRequest!.Nombre));
            }

            if(!string.IsNullOrEmpty(request.InstructorRequest!.Apellido))
            {
                predicate = predicate
                .And(y => y.Apellido!.Contains(request.InstructorRequest!.Apellido));
            }

            if(!string.IsNullOrEmpty(request.InstructorRequest.OrderBy))
            {
                Expression<Func<Instructor, object>>? orderBySelector = 
                request.InstructorRequest.OrderBy.ToLower() switch 
                {
                    "nombre" => instructor => instructor.Nombre!,
                    "apellido" => instructor => instructor.Apellido!,
                    _ => instructor => instructor.Nombre!
                };

                bool orderBy = request.InstructorRequest.OrderAsc.HasValue 
                            ? request.InstructorRequest.OrderAsc.Value
                            : true;

                queryable = orderBy 
                            ? queryable.OrderBy(orderBySelector)
                            : queryable.OrderByDescending(orderBySelector);
            }

            queryable = queryable.Where(predicate);

            var instructoresQuery = queryable
                        .ProjectTo<InstructorDto>(_mapper.ConfigurationProvider)
                        .AsQueryable();

            var pagination = await PagedList<InstructorDto>
                .CreateAsync(instructoresQuery, 
                request.InstructorRequest.PageNumber,
                request.InstructorRequest.PageSize
                );

            return Result<PagedList<InstructorDto>>.Success(pagination);
        }
    }
}




public record InstructorDto(
    Guid? Id,
    string? Nombre,
    string? Apellido,
    string? Grado
)
{
    public InstructorDto() : this(null, null, null, null)
    {
    }
}