using WakeCommerce.Api.Entities;

namespace WakeCommerce.Api.Repositories
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> ObterTodosAsync(string? nome, string? ordem);
        Task<Produto?> ObterPorIdAsync(int id);
        Task AdicionarAsync(Produto produto);
        Task AtualizarAsync(Produto produto);
        Task DeletarAsync(int id);
    }
}
