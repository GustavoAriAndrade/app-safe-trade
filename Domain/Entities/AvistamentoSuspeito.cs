namespace api_safe_trade.Domain.Entities
{
    public class AvistamentoSuspeito
    {
        public int Id { get; set; }
        public float Confidence { get; set; }
        public DateTime CreatedAt { get; set; }
        public required Suspeito Suspeito { get; set; }
        public required Camera Camera { get; set; }
    }
}
