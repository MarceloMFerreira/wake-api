using WakeCommerce.Api.Entities;

namespace WakeCommerce.Api.Services
{
    public interface IProdutoService
    {
        Task<List<Produto>> ObterTodosAsync(string? nome, string? ordem);
        Task<Produto?> ObterPorIdAsync(int id);
        Task AdicionarAsync(Produto produto);
        Task AtualizarAsync(Produto produto);
        Task DeletarAsync(int id);
    }
}
