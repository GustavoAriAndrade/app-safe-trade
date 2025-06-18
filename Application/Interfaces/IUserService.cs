using api_safe_trade.Domain.Entities;

namespace api_safe_trade.Application.Interfaces
{
    public interface IUserService
    {
        Task CreateUserAsync(Usuario input);
    }
}
