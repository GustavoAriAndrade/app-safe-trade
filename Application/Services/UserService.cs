using api_safe_trade.Application.Interfaces;
using api_safe_trade.Domain.Entities;
using api_safe_trade.Infrastructure.Data;

namespace api_safe_trade.Application.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(Usuario input)
        {
            _context.Usuarios.Add(input);

            await _context.SaveChangesAsync();
        }
    }
}
