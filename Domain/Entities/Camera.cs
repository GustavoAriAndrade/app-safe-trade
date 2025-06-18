namespace api_safe_trade.Domain.Entities
{
    public class Camera
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string IpAddress { get; set; }
        public List<AvistamentoSuspeito>? Avistamentos { get; set; }
    }
}
