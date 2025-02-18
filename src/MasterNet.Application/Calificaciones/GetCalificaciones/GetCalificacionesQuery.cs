namespace MasterNet.Application.Calificaiones.GetCalificaciones;

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

