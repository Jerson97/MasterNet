using FluentValidation;

namespace MasterNet.Application.Cursos.Update;

public class CursoUpdateValidator : AbstractValidator<CursoUpdateRequest>
{
    public CursoUpdateValidator()
    {
        RuleFor(x => x.Titulo).NotEmpty().WithMessage("El titulo no debe ser vacio");
        RuleFor(x => x.Descripcion).NotEmpty().WithMessage("La descripcion no debe estar vacia");
    }
}