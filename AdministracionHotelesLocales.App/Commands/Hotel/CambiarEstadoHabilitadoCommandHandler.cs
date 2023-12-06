using AdministracionHotelesLocales.Domain.Services.HotelServices;
using MediatR;

namespace AdministracionHotelesLocales.App.Commands.Hotel
{
    public record CambiarEstadoHabilitadoCommandHandler : IRequestHandler<CambiarEstadoHabilitadoCommand>
    {
        private readonly HotelService _hotelService;
        public CambiarEstadoHabilitadoCommandHandler(HotelService hotelService)
        {
            _hotelService = hotelService;
        }
        public async Task<Unit> Handle(CambiarEstadoHabilitadoCommand request, CancellationToken cancellationToken)
        {
            await _hotelService.ModificarEstadoHotel(request.Id, request.Habilitado, cancellationToken);

            return Unit.Value;
        }
    }
}
