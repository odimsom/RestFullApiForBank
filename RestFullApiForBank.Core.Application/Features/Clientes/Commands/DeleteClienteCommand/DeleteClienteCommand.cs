using AutoMapper;
using MediatR;
using RestFullApiForBank.Core.Application.Interfaces;
using RestFullApiForBank.Core.Application.Wrappers;
using RestFullApiForBank.Core.Domain.Entities;

namespace RestFullApiForBank.Core.Application.Features.Clientes.Commands.DeleteClienteCommand
{
    public class DeleteClienteCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Cliente> _repository;
        private readonly IMapper _mapper;
        public DeleteClienteCommandHandler(IRepositoryAsync<Cliente> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (cliente == null)
            {
                throw new KeyNotFoundException($"Registro No Entocontrado Con el Id {request.Id}");
            }
            await _repository.DeleteAsync(cliente, cancellationToken);

            return new Response<int>
            {
                Succeeded = true,
                Message = "Cliente Delete successfully",
                Data = cliente.Id
            };
        }
    }
}
