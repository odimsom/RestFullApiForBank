using Ardalis.Specification;
using RestFullApiForBank.Core.Domain.Entities;

namespace RestFullApiForBank.Core.Application.Specifications
{
    public class PagedClienteSpesification : Specification<Cliente>
    {
        public PagedClienteSpesification(string name, string lastName, int pageNumber, int pageSize)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            if (!string.IsNullOrEmpty(name))
                Query.Search(c => c.Nombre, "%" + name + "%");

            if (!string.IsNullOrEmpty(lastName))
                Query.Search(c => c.LastName, "%" + lastName + "%");
        }
    }
}