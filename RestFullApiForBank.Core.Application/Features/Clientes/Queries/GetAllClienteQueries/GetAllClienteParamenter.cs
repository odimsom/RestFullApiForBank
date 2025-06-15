using RestFullApiForBank.Core.Application.Parameters;

namespace RestFullApiForBank.Core.Application.Features.Clientes.Queries.GetAllClienteQueries
{
    public class GetAllClienteParamenter : RequestParameter
    {
        public string Nombre { get; set; }
        public string LastName { get; set; }
    }
}
