using AdministracionHotelesLocales.Domain.Entities;
using AdministracionHotelesLocales.Domain.Ports.Repositories;
using AdministracionHotelesLocales.Infra.Ports;
using System.Linq.Expressions;

namespace AdministracionHotelesLocales.Infra.Adapters
{
    [Repository]
    public class HotelesRepository : IHotelesRepository
    {
        private readonly IGenericRepository<Hotel> _hotelDataSet;
        private readonly IGenericRepository<Habitacion> _habitacionesDataSet;
        public HotelesRepository(IGenericRepository<Hotel> hotelDataSet, IGenericRepository<Habitacion> habitacionesDataSet)
        {
            _hotelDataSet = hotelDataSet;
            _habitacionesDataSet = habitacionesDataSet;
        }

        public async Task ActualizarEstadoHabilitadoHotel(Hotel hotel)
        {
            await _hotelDataSet.UpdateAsync(hotel);
        }

        public async Task<Hotel> CrearNuevoHotel(Hotel hotel)
        {
            await _hotelDataSet.AddAsync(hotel);
            return hotel;
        }

        public async Task<IEnumerable<Hotel>> ListarHoteles(Expression<Func<Hotel, bool>> filter = null!)
        {
            return await _hotelDataSet.GetAsync();
        }

        public async Task ModificarValoresHotel(Hotel hotel)
        {
            await _hotelDataSet.UpdateAsync(hotel);
        }

        public async Task<Hotel> ObtenerHotelPorId(Guid id)
        {
            var hotel = await _hotelDataSet.GetByIdAsync(id);
            return hotel;
        }
    }
}
