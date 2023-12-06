using AdministracionHotelesLocales.Domain.Entities;
using System.Linq.Expressions;

namespace AdministracionHotelesLocales.Domain.Ports.Repositories
{
    public interface IHotelesRepository
    {
        Task<Hotel> CrearNuevoHotel(Hotel hotel);
        Task ModificarValoresHotel(Hotel hotel);
        Task<IEnumerable<Hotel>> ListarHoteles(Expression<Func<Hotel, bool>> filter = null!);
        Task<Hotel> ObtenerHotelPorId(Guid id);
        Task ActualizarEstadoHabilitadoHotel(Hotel hotel);
    }

}
