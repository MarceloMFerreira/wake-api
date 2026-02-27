namespace WakeCommerce.Api.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Estoque { get; set; }
        public decimal Valor { get; set; }
    }
}
