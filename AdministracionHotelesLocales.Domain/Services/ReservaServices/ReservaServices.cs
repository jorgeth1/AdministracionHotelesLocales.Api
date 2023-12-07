using AdministracionHotelesLocales.Domain.Entities;
using AdministracionHotelesLocales.Domain.Exceptions;
using AdministracionHotelesLocales.Domain.Filters;
using AdministracionHotelesLocales.Domain.Ports.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace AdministracionHotelesLocales.Domain.Services.ReservaServices
{
    [DomainService]
    public class ReservaServices
    {
        private readonly IReservasRepository _reservasRepository;
        private readonly IHabitacionesRepository _habitacionesRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ReservaServices(IReservasRepository reservasRepository,
            IHabitacionesRepository habitacionesRepository,
            IUnitOfWork unitOfWork)
        {
            _reservasRepository = reservasRepository;
            _habitacionesRepository = habitacionesRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Reserva> ReservarHabitacion(Reserva reserva, CancellationToken cancellationToken)
        {
            cancellationToken = cancellationToken == default ? new CancellationToken() : cancellationToken;
            var habitacion = await _habitacionesRepository.ObtenerHabitacionPorId(reserva.HabitacionId);

            _ = habitacion is null ? throw new AppException("La Habitacion no existe") : false;
            _ = habitacion.Disponible ? false : throw new AppException("No es posible reservar la habitación");

            await _reservasRepository.ReservarHabitacion(reserva);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return reserva;
        }

        public async Task<IEnumerable<Reserva>> FiltrarReservasPorDisponibilidadFecha(FiltroConsultaHabitaciones filtroConsultaHabitaciones)
        {
            _ = filtroConsultaHabitaciones.FechaEntrada.Date < DateTime.Now.Date
                || filtroConsultaHabitaciones.FechaSalida.Date <= DateTime.Now.Date
                ? throw new AppException("La fecha de entrada de reserva no es valida") : false;

            return await _reservasRepository.FiltrarReservas(filtroConsultaHabitaciones);
        }

    }
}
