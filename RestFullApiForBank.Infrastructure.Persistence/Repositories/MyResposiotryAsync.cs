using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestFullApiForBank.Core.Application.Interfaces;

namespace RestFullApiForBank.Infrastructure.Persistence.Repositories
{
    public class MyResposiotryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly DbContext _context;
        public MyResposiotryAsync(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}