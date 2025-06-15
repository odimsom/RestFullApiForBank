using AutoMapper;
using MediatR;
using RestFullApiForBank.Core.Application.Interfaces;
using RestFullApiForBank.Core.Application.Wrappers;
using RestFullApiForBank.Core.Domain.Entities;

namespace RestFullApiForBank.Core.Application.Features.Clientes.Commands.UpdateClienteCommand
{
    public class UpdateClienteCommand : IRequest<Response<int>>
    {
        public required int Id { get; set; }
        public required string Nombre { get; set; }
        public required string LastName { get; set; }
        public DateTime FechaDeNacimineto { get; set; }
        public required string Telefono { get; set; }
        public required string Email { get; set; }
        public string? Direccion { get; set; }
    }
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Cliente> _repository;
        private readonly IMapper _mapper;

        public UpdateClienteCommandHandler(IRepositoryAsync<Cliente> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (cliente == null)
            {
                return new Response<int>
                {
                    Succeeded = false,
                    Message = "Cliente not found",
                    Errors = new List<string> { "Invalid Cliente ID" },
                    Data = 0
                };
            }

            cliente.Nombre = request.Nombre;
            cliente.LastName = request.LastName;
            cliente.FechaDeNacimineto = request.FechaDeNacimineto;
            cliente.Telefono = request.Telefono;
            cliente.Email = request.Email;
            cliente.Direccion = request.Direccion ?? cliente.Direccion;

            await _repository.UpdateAsync(cliente, cancellationToken);

            return new Response<int>
            {
                Succeeded = true,
                Message = "Cliente updated successfully",
                Data = cliente.Id
            };
        }
    }
}
