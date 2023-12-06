using AdministracionHotelesLocales.Domain.Entities;
using AdministracionHotelesLocales.Domain.Enums;
using AdministracionHotelesLocales.Domain.Exceptions;
using AdministracionHotelesLocales.Domain.Ports.Repositories;

namespace AdministracionHotelesLocales.Domain.Services.HabitacionServices
{
    [DomainService]
    public class HabitacionServices
    {
        private readonly IHabitacionesRepository _habitacionesRepository;
        private readonly IHotelesRepository _hotelesRepository;
        private readonly IUnitOfWork _unitOfWork;
        public HabitacionServices(IHabitacionesRepository habitacionesRepository,
            IHotelesRepository hotelesRepository,
            IUnitOfWork unitOfWork)
        {
            _habitacionesRepository = habitacionesRepository;
            _hotelesRepository = hotelesRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Habitacion> CrearUnaHabitacion(Habitacion habitacion, CancellationToken cancellationToken)
        {
            cancellationToken = cancellationToken == default ? new CancellationToken() : cancellationToken;

            var hotel = await _hotelesRepository.ObtenerHotelPorId(habitacion.HotelId);

            if (hotel is not null)
            {
                await _habitacionesRepository.CrearNuevaHabitacion(habitacion);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return habitacion;
            }

            throw new AppException("El hotel al que se va a agregar la habitacion no existe");
        }

        public async Task<Habitacion> ModificarUnaHabitacion(Habitacion habitacion, CancellationToken cancellationToken)
        {
            cancellationToken = cancellationToken == default ? new CancellationToken() : cancellationToken;

            var habitacionExistente = await _habitacionesRepository.ObtenerHabitacionPorId(habitacion.Id);

            _ = habitacionExistente is null ? throw new AppException("La habitacion no existe") : false;

            habitacionExistente.Capacidad = habitacion.Capacidad;
            habitacionExistente.CostoBase = habitacion.CostoBase;
            habitacionExistente.Impuestos = habitacion.Impuestos;
            habitacionExistente.Tipo = habitacion.Tipo;
            habitacionExistente.Ubicacion = habitacion.Ubicacion;

            await _habitacionesRepository.ModificarValoresHabitacion(habitacionExistente);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return habitacionExistente;
        }

        public async Task<Habitacion> ActualizarEstadoPorHabitacion(Guid id, bool estado, CancellationToken cancellationToken)
        {
            cancellationToken = cancellationToken == default ? new CancellationToken() : cancellationToken;

            var habitacionExistente = await _habitacionesRepository.ObtenerHabitacionPorId(id);

            _ = habitacionExistente is null ? throw new AppException("La habitacion no existe") : false;

            habitacionExistente.Disponible = estado;
            await _habitacionesRepository.ModificarValoresHabitacion(habitacionExistente);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return habitacionExistente;
        }

    }
}
