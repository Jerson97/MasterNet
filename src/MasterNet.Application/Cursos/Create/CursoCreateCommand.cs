using FluentValidation;
using MasterNet.Application.Core;
using MasterNet.Application.Interface;
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
        private readonly IPhotoService _photoService;

        public CursosCreateCommandHandler(MasterNetDbContext context, IPhotoService photoService)
        {
            _context = context;
            _photoService = photoService;
        }

        public async Task<Result<Guid>> Handle(CursoCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var cursoId = Guid.NewGuid();
            var curso = new Curso(){
                Id = cursoId,
                Titulo = request.CursoCreateRequest.Titulo,
                Descripcion = request.CursoCreateRequest.Descripcion,
                FechaPublicacion = DateTime.Now

            };

            if (request.CursoCreateRequest.Foto is not null)
            {
                var photoUploadResult = await _photoService.AddPhoto(request.CursoCreateRequest.Foto);

                var photo = new Photo
                {
                    Id = Guid.NewGuid(),
                    Url =photoUploadResult.Url,
                    PublicId = photoUploadResult.PublicId,
                    CursoId = cursoId
                };
                curso.Photos = new List<Photo>(){ photo };
            }



            _context.Add(curso);

            var resultado = await _context.SaveChangesAsync() > 0;
            return resultado ? Result<Guid>.Success(curso.Id)
                             : Result<Guid>.Failure("No se pudo insertal el curso");
        }
    }

    public class CursosCreateCommandRequestValidator : AbstractValidator<CursoCreateCommandRequest>
    {
        public CursosCreateCommandRequestValidator()
        {
            RuleFor(x => x.CursoCreateRequest).SetValidator(new CursoCreateValidator());
        }
    }
}