using AdministracionHotelesLocales.Domain.Services.HotelServices;
using MediatR;

namespace AdministracionHotelesLocales.App.Commands.Hotel
{
    public class ModificarHotelCommandHandler : IRequestHandler<ModificarHotelCommand>
    {
        private readonly HotelService _hotelService;
        public ModificarHotelCommandHandler(HotelService hotelService)
        {
            _hotelService = hotelService;
        }
        public async Task<Unit> Handle(ModificarHotelCommand request, CancellationToken cancellationToken)
        {
            await _hotelService.ModificarValoresHotel(new()
            {
                Id = request.Id,
                Nombre = request.Nombre,
                Estrellas = request.Estrellas,
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
