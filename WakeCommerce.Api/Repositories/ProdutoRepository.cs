using Microsoft.EntityFrameworkCore;
using WakeCommerce.Api.Data;
using WakeCommerce.Api.Entities;

namespace WakeCommerce.Api.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Produto>> ObterTodosAsync(string? nome, string? ordem)
        {
            var query = _context.Produtos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nome))
            {
                query = query.Where(p => p.Nome.Contains(nome));
            }

            var produtos = await query.ToListAsync();

            if (string.IsNullOrEmpty(ordem))
            {
                return produtos.OrderBy(p => p.Id).ToList();
            }

            switch (ordem.ToLower())
            {
                case "nome":
                    return produtos.OrderBy(p => p.Nome).ToList();
                case "valor":
                    return produtos.OrderBy(p => p.Valor).ToList();
                case "estoque":
                    return produtos.OrderBy(p => p.Estoque).ToList();
                default:
                    return produtos.OrderBy(p => p.Id).ToList();
            }
        }
        public async Task<Produto?> ObterPorIdAsync(int id) => await _context.Produtos.FindAsync(id);

        public async Task AdicionarAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
