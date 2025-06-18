using api_safe_trade.Domain.Entities;

namespace api_safe_trade.Application.Interfaces
{
    public interface ICameraService
    {
        Task CreateAsync(Camera input);
        Task<List<Camera>> GetListAsync();
        Task<Camera> GetByIdAsync(int id);
        Task UpdateAsync(Camera input);
    }
}