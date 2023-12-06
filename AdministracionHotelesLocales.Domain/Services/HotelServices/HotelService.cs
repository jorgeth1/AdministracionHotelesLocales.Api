using AdministracionHotelesLocales.Domain.Entities;
using AdministracionHotelesLocales.Domain.Exceptions;
using AdministracionHotelesLocales.Domain.Ports.Repositories;

namespace AdministracionHotelesLocales.Domain.Services.HotelServices
{
    [DomainService]
    public class HotelService
    {
        private readonly IHotelesRepository _hotelRepository;
        private readonly IUnitOfWork _unitOfWork;
        public HotelService(IHotelesRepository hotelRepository, IUnitOfWork unitOfWork)
        {
            _hotelRepository = hotelRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Hotel> AgregarHotel(Hotel hotel, CancellationToken cancellationToken)
        {
            cancellationToken = cancellationToken == default ? new CancellationToken() : cancellationToken;

            if (hotel is not null)
            {
                await _hotelRepository.CrearNuevoHotel(hotel);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return hotel;
            }

            throw new AppException("El Hotel no cuenta con los campos necesarios para ser creado");

        }

        public async Task ModificarValoresHotel(Hotel hotel, CancellationToken cancellationToken)
        {
            cancellationToken = cancellationToken == default ? new CancellationToken() : cancellationToken;

            var hotelExistente = await _hotelRepository.ObtenerHotelPorId(hotel.Id);

            _ = hotelExistente is null ? throw new AppException("El Hotel no existe") : false;

            hotelExistente.Estrellas = hotel.Estrellas;
            hotelExistente.Nombre = hotel.Nombre;

            await _hotelRepository.ModificarValoresHotel(hotelExistente);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

        }

        public async Task ModificarEstadoHotel(Guid id, bool estado, CancellationToken cancellationToken)
        {
            cancellationToken = cancellationToken == default ? new CancellationToken() : cancellationToken;


            var hotelExistente = await _hotelRepository.ObtenerHotelPorId(id);

            _ = hotelExistente is null ? throw new AppException("El Hotel no existe") : false;

            hotelExistente.Disponible = estado;

            await _hotelRepository.ModificarValoresHotel(hotelExistente);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

        }

        public async Task<IEnumerable<Hotel>> ListaHoteles()
        {
            return await _hotelRepository.ListarHoteles();
        }
    }
}
