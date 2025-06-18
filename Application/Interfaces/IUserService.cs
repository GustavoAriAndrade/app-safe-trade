using api_safe_trade.Domain.Entities;

namespace api_safe_trade.Application.Interfaces
{
    public interface IUserService
    {
        Task CreateAsync(Usuario input);
        Task<List<Usuario>> GetListAsync();
        Task<Usuario> GetByIdAsync(int id);
        Task UpdateAsync(Usuario input);
    }
}
