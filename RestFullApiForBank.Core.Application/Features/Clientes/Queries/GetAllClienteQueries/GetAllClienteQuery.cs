using AutoMapper;
using MediatR;
using RestFullApiForBank.Core.Application.DTOs.ClienteDtos;
using RestFullApiForBank.Core.Application.Interfaces;
using RestFullApiForBank.Core.Application.Specifications;
using RestFullApiForBank.Core.Application.Wrappers;
using RestFullApiForBank.Core.Domain.Entities;

namespace RestFullApiForBank.Core.Application.Features.Clientes.Queries.GetAllClienteQueries
{
    public class GetAllClienteQuery : IRequest<PagedResponse<List<ClienteDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Nombre { get; set; }
        public string LastName { get; set; }

        public class GetAllClienteQueryHandler : IRequestHandler<GetAllClienteQuery, PagedResponse<List<ClienteDto>>>
        {
            private readonly IRepositoryAsync<Cliente> _repository;
            private readonly IMapper _mapper;
            public GetAllClienteQueryHandler(IRepositoryAsync<Cliente> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<PagedResponse<List<ClienteDto>>> Handle(GetAllClienteQuery request, CancellationToken cancellationToken)
            {
                var clientes = await _repository.ListAsync(new PagedClienteSpesification
                    (
                        request.Nombre,
                        request.LastName,
                        request.PageNumber,
                        request.PageNumber
                    ));

                var clienteDtos = _mapper.Map<List<ClienteDto>>(clientes);

                return new PagedResponse<List<ClienteDto>>(clienteDtos, request.PageNumber, request.PageSize);
            }
        }
    }
}