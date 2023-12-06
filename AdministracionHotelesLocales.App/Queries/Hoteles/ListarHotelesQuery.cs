using AdministracionHotelesLocales.App.Dtos;
using MediatR;

namespace AdministracionHotelesLocales.App.Queries.Hoteles
{
    public record ListarHotelesQuery() : IRequest<IEnumerable<HotelDto>>;
}
