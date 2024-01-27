using Farmacia.Application.UseCase.UseCases.Medic.Commands.CreateCommand;
using Farmacia.Application.UseCase.UseCases.Medic.Commands.UpdateCommand;
using Farmacia.Application.UseCase.UseCases.Medic.Queries.GetAllQuery;
using Farmacia.Application.UseCase.UseCases.Medic.Queries.GetByIdQuery;
using Farmacia.Application.UseCase.UseCases.Patient.Commands.DeleteCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Farmacia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListMedics")]
        public async Task<IActionResult> ListMedics()
        {
            var response = await _mediator.Send(new GetAllMedicQuery());

            return Ok(response);
        }

        [HttpGet("MedicById/{medicId:int}")]
        public async Task<IActionResult> GetMedicById(int medicId)
        {
            var response = await _mediator.Send(new GetMedicByIdQuery() { MedicId = medicId});

            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterMedic([FromBody] CreateMedicCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditMedic([FromBody] UpdateMedicCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete("Delete/{medicId:int}")]
        public async Task<IActionResult> EditMedic(int medicId)
        {
            var response = await _mediator.Send(new DeleteMedicCommand() { MedicId = medicId});

            return Ok(response);
        }
    }
}
