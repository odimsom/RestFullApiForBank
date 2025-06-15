using AutoMapper;
using MediatR;
using RestFullApiForBank.Core.Application.DTOs.ClienteDtos;
using RestFullApiForBank.Core.Application.Interfaces;
using RestFullApiForBank.Core.Application.Wrappers;
using RestFullApiForBank.Core.Domain.Entities;

namespace RestFullApiForBank.Core.Application.Features.Clientes.Queries.GetClienteByIdQueries
{
    public class GetClienteByIdQuery : IRequest<Response<ClienteDto>>
    {
        public int Id { get; set; }
        public class GetClienteQyIdQueryHandler : IRequestHandler<GetClienteByIdQuery, Response<ClienteDto>>
        {
            private readonly IRepositoryAsync<Cliente> _repository;
            private readonly IMapper _mapper;
            public GetClienteQyIdQueryHandler(IRepositoryAsync<Cliente> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            } 
            public async Task<Response<ClienteDto>> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
            {
                var cliente = await _repository.GetByIdAsync(request.Id, cancellationToken);
                if (cliente == null)
                {
                    return new Response<ClienteDto>
                    {
                        Succeeded = false,
                        Message = "Cliente not found",
                        Errors = new List<string> { "Invalid Cliente ID" },
                        Data = null!
                    };
                }
                var dto = _mapper.Map<ClienteDto>(cliente);

                return new Response<ClienteDto>(dto);
            }
        }
    }
}