namespace MasterNet.Application.Instructores.GetInstructores;

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