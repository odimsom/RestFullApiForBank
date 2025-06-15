using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestFullApiForBank.Core.Application.Interfaces;
using RestFullApiForBank.Infrastructure.Persistence.Context;

namespace RestFullApiForBank.Infrastructure.Persistence.Repositories
{
    public class MyResposiotryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public MyResposiotryAsync(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}