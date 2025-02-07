namespace MasterNet.Domain;

public class Instructor : BaseEntity
{
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Grado { get; set; }
    public ICollection<Curso>? Curso { get; set; }
    public ICollection<CursoInstructor>? CursoInstructores { get; set; }
}