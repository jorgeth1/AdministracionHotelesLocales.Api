using AdministracionHotelesLocales.App.Dtos;
using AdministracionHotelesLocales.Domain.Services.HotelServices;
using AutoMapper;
using MediatR;

namespace AdministracionHotelesLocales.App.Commands.Hotel
{
    public class CrearHotelCommandHandler : IRequestHandler<CrearHotelCommand, HotelDto>
    {
        private readonly IMapper _mapper;
        private readonly HotelService _hotelServices;
        public CrearHotelCommandHandler(IMapper mapper, HotelService hotelService)
        {
            _hotelServices = hotelService;
            _mapper = mapper;
        }
        public async Task<HotelDto> Handle(CrearHotelCommand request, CancellationToken cancellationToken)
        {
            var newHotel = await _hotelServices.AgregarHotel(new()
            {
                Nombre = request.Nombre,
                Estrellas = request.Estrellas,
                Disponible = request.Disponible
            }, cancellationToken);

            var newHotelDto = _mapper.Map<HotelDto>(newHotel);
            return newHotelDto;
        }
    }
}
