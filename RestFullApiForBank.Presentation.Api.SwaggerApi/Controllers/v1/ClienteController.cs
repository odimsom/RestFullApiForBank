using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestFullApiForBank.Core.Application.Features.Clientes.Commands.CreateClienteCommand;
using RestFullApiForBank.Core.Application.Features.Clientes.Commands.DeleteClienteCommand;
using RestFullApiForBank.Core.Application.Features.Clientes.Commands.UpdateClienteCommand;
using RestFullApiForBank.Core.Application.Features.Clientes.Queries.GetAllClienteQueries;
using RestFullApiForBank.Core.Application.Features.Clientes.Queries.GetClienteByIdQueries;

namespace RestFullApiForBank.Presentation.Api.SwaggerApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ClienteController : BaseApiController
    {
        [HttpGet()]
        public async Task<IActionResult> GetAllfilter([FromRoute] GetAllClienteParamenter filter)
        {
            return Ok(await Mediator.Send(new GetAllClienteQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                Nombre = filter.Nombre,
                LastName = filter.LastName
            }));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetClienteByIdQuery { Id = id }));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateClienteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateClienteCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteClienteCommand {Id = id}));
        }
    }
}