using AutoMapper;
using RestFullApiForBank.Core.Application.DTOs.ClienteDtos;
using RestFullApiForBank.Core.Application.Features.Clientes.Commands.CreateClienteCommand;
using RestFullApiForBank.Core.Domain.Entities;

namespace RestFullApiForBank.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DTOs
            CreateMap<Cliente, ClienteDto>();
            #endregion

            #region Commands
            CreateMap<CreateClienteCommand, Cliente>();
            #endregion
        }
    }
}
