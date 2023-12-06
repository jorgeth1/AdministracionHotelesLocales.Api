using AdministracionHotelesLocales.App.Commands.Hotel;
using AdministracionHotelesLocales.App.Dtos;
using AdministracionHotelesLocales.App.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdministracionHotelesLocales.Api.Controllers
{
    [Route("api/hoteles")]
    [ApiController]
    public class HotelesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HotelesController(IMediator mediator) => _mediator = mediator;


        //[HttpGet]
        //public async Task<IEnumerable<HotelDto>> ListarHoteles()
        //    => await _mediator.Send(new ListarHotelesQuery());

        [HttpPost]
        public async Task<HotelDto> CrearHotel([FromBody] CrearHotelCommand crearHotelCommand)
            => await _mediator.Send(crearHotelCommand);

        [HttpPut]
        public async Task ModificarHotel([FromBody] ModificarHotelCommand modificarHotelCommand)
            => await _mediator.Send(modificarHotelCommand);

        [HttpPut("cambiar-estado-habilitado")]
        public async Task CambiarEstadoHotel([FromBody] CambiarEstadoHabilitadoCommand cambiarEstadoHotelCommand)
            => await _mediator.Send(cambiarEstadoHotelCommand);
    }
}
