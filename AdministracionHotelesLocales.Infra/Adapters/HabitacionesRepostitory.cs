using AdministracionHotelesLocales.Domain.Entities;
using AdministracionHotelesLocales.Domain.Ports.Repositories;
using AdministracionHotelesLocales.Infra.Ports;

namespace AdministracionHotelesLocales.Infra.Adapters
{
    [Repository]
    public class HabitacionesRepostitory : IHabitacionesRepository
    {
        private readonly IGenericRepository<Habitacion> _habitacionDataSet;
        public HabitacionesRepostitory(IGenericRepository<Habitacion> habitacionGenericRepository)
        {
            _habitacionDataSet = habitacionGenericRepository;
        }
        public async Task<Habitacion> CrearNuevaHabitacion(Habitacion habitacion)
        {
            await _habitacionDataSet.AddAsync(habitacion);

            return habitacion;
        }

        public async Task ModificarValoresHabitacion(Habitacion habitacion)
        {
            await _habitacionDataSet.UpdateAsync(habitacion);
        }

        public async Task<Habitacion> ObtenerHabitacionPorId(Guid id)
        {
            return await _habitacionDataSet.GetByIdAsync(id);
        }
    }
}
