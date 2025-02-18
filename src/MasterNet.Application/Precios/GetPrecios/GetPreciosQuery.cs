namespace MasterNet.Application.Precios.GetPrecios;

public record PrecioDto(
    Guid? Id,
    string? Nombre,
    decimal? PrecioActual,
    decimal? PrecioPromocion
)

{
    public PrecioDto() : this(null, null, null, null)
    {
        
    }
}