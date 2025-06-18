using api_safe_trade.Domain.Enums;

namespace api_safe_trade.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public bool Status { get; set; }
        public RoleEnum Role { get; set; }
        public List<AbordagemSuspeito>? Abordagens { get; set; }
    }
}
