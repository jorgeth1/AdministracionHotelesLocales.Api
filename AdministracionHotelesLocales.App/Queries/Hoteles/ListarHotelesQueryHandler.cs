using AdministracionHotelesLocales.App.Dtos;
using AdministracionHotelesLocales.Domain.Ports.Repositories;
using AdministracionHotelesLocales.Domain.Services.HotelServices;
using AutoMapper;
using MediatR;

namespace AdministracionHotelesLocales.App.Queries.Hoteles
{
    public class ListarHotelesQueryHandler : IRequestHandler<ListarHotelesQuery, IEnumerable<HotelDto>>
    {
        private readonly IMapper _mapper;
        private readonly HotelService _hotelService;
        public ListarHotelesQueryHandler(IMapper mapper, HotelService hotelService)
        {
            _mapper = mapper;
            _hotelService = hotelService;
        }

        public async Task<IEnumerable<HotelDto>> Handle(ListarHotelesQuery request, CancellationToken cancellationToken)
        {
            var hoteles = (await _hotelService.ListaHoteles()).ToList();
            var hotelDtos = _mapper.Map<List<HotelDto>>(hoteles);

            return hotelDtos;
        }
    }
}
