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

        public async Task CreateAsync(Usuario input)
        {
            _context.Usuarios.Add(input);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Usuario>> GetListAsync()
        {
            return await _context.Usuarios.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateAsync(Usuario input)
        {
            var existingUser = await _context.Usuarios.FirstOrDefault(x = x => x.Id == input.Id);

            if (existingUser is null)
                throw new Exception("Usuário não existe");

            _context.Usuarios.Entry(existingUser).CurrentValues.SetValues(input);

            await _context.SaveChangesAsync();
        }
    }
}
