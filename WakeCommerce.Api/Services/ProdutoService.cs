using WakeCommerce.Api.Entities;
using WakeCommerce.Api.Repositories;

namespace WakeCommerce.Api.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Produto>> ObterTodosAsync(string? nome, string? ordem)
        {
            return _repository.ObterTodosAsync(nome, ordem);
        }

        public async Task<Produto?> ObterPorIdAsync(int id)
        {
            return await _repository.ObterPorIdAsync(id);
        }

        public async Task AdicionarAsync(Produto produto)
        {
            if (produto.Valor < 0)
                throw new Exception("O valor do produto não pode ser negativo.");

            await _repository.AdicionarAsync(produto);
        }

        public async Task AtualizarAsync(Produto produto)
        {
            if (produto.Valor < 0)
                throw new Exception("O valor do produto não pode ser negativo.");

            await _repository.AtualizarAsync(produto);
        }

        public Task DeletarAsync(int id)
        {
            return _repository.DeletarAsync(id);
        }
    }
}
