using AutoMapper;
using MediatR;
using RestFullApiForBank.Core.Application.Interfaces;
using RestFullApiForBank.Core.Application.Wrappers;
using RestFullApiForBank.Core.Domain.Entities;

namespace RestFullApiForBank.Core.Application.Features.Clientes.Commands.CreateClienteCommand
{
    public class CreateClienteCommand : IRequest<Response<int>>
    {
        public required string Nombre { get; set; }
        public required string LastName { get; set; }
        public DateTime FechaDeNacimineto { get; set; }
        public required string Telefono { get; set; }
        public required string Email { get; set; }
        public string? Direccion { get; set; }
    }
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Cliente> _repository;
        private readonly IMapper _mapper;

        public CreateClienteCommandHandler(IRepositoryAsync<Cliente> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<Cliente>(request);
            var data = await _repository.AddAsync(nuevoRegistro);

            return new Response<int>(data.Id);
        }
    }
}
