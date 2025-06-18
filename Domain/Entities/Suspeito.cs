namespace api_safe_trade.Domain.Entities
{
    public class Suspeito
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string IdentifierVirtual { get; set; }
        public required string Observation { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<AvistamentoSuspeito>? Avistamentos { get; set; }
        public List<AbordagemSuspeito>? Abordagens { get; set; }
    }
}
