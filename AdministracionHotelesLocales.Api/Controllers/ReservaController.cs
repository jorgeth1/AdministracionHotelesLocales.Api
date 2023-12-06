using AdministracionHotelesLocales.App.Commands.Reservas;
using AdministracionHotelesLocales.App.Dtos;
using AdministracionHotelesLocales.App.Queries.Reservas;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionHotelesLocales.Api.Controllers
{
    [Route("api/reservas")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReservaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("filtrar-por-fecha")]
        public async Task<IEnumerable<HabitacionDto>> RealizarReserva([FromBody] FiltrarReservasQuery realizarReservaCommand)
            => await _mediator.Send(realizarReservaCommand);

        [HttpPost]
        public async Task<ReservaDto> RealizarReserva([FromBody] RealizarReservaCommand realizarReservaCommand)
            => await _mediator.Send(realizarReservaCommand);


    }
}
