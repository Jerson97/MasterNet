namespace MasterNet.Application.Photos.GetPhoto;

public record PhotoDto(
    Guid? Id,
    string? Url,
    Guid? CursoId
)

{
    public PhotoDto(): this(null, null, null)
    {

    }

}