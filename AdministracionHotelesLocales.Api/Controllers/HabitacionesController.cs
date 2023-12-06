using AdministracionHotelesLocales.App.Commands.Habitacion;
using AdministracionHotelesLocales.App.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionHotelesLocales.Api.Controllers
{
    [Route("api/habitaciones")]
    [ApiController]
    public class HabitacionesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HabitacionesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<HabitacionDto> CrearHabitacion([FromBody] CrearHabitacionCommand crearHabitacionCommand)
            => await _mediator.Send(crearHabitacionCommand);

        [HttpPut]
        public async Task ModificarHabitacion([FromBody] ModificarHabitacionCommand modificarHabitacionCommand)
            => await _mediator.Send(modificarHabitacionCommand);

        [HttpPut("cambiar-estado-habilitado")]
        public async Task CambiarEstadoHabilitadoHabitacionHabitacion([FromBody] CambiarEstadoHabilitadoHabitacionCommand cambiarEstadoHabilitadoHabitacionCommand)
            => await _mediator.Send(cambiarEstadoHabilitadoHabitacionCommand);
    }
}
