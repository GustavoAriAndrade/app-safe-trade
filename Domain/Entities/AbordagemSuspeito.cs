namespace api_safe_trade.Domain.Entities
{
    public class AbordagemSuspeito
    {
        public int Id { get; set; }
        public required string Observation { get; set; }
        public DateTime CreatedAt { get; set; }
        public required Usuario Usuario { get; set; }
        public required Suspeito Suspeito { get; set; }
    }
}
