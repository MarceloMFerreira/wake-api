using Moq;
using WakeCommerce.Api.Entities;
using WakeCommerce.Api.Repositories;
using WakeCommerce.Api.Services;
using Xunit;

namespace WakeCommerce.Tests;

public class ProdutoServiceTests
{
    private readonly Mock<IProdutoRepository> _repositoryMock;
    private readonly ProdutoService _service;

    public ProdutoServiceTests()
    {
        _repositoryMock = new Mock<IProdutoRepository>();
        _service = new ProdutoService(_repositoryMock.Object);
    }

    [Fact]
    public async Task Adicionar_LancarExcecao_ValorNegativo()
    {
        var produtoInvalido = new Produto { Nome = "Teste", Valor = -10, Estoque = 1 };

        var exception = await Assert.ThrowsAsync<Exception>(() => _service.AdicionarAsync(produtoInvalido));
        Assert.Equal("O valor do produto não pode ser negativo.", exception.Message);
    }

    [Fact]
    public async Task Adicionar_ChamarRepositorio_ProdutoValido()
    {
        var produtoValido = new Produto { Nome = "Produto OK", Valor = 100, Estoque = 10 };

        await _service.AdicionarAsync(produtoValido);

        _repositoryMock.Verify(r => r.AdicionarAsync(It.IsAny<Produto>()), Times.Once);
    }

    [Fact]
    public async Task ObterPorId_RetornaProduto_QuandoIdExistir()
    {
        var produtoEsperado = new Produto { Id = 1, Nome = "Mouse", Valor = 50 };
        _repositoryMock.Setup(r => r.ObterPorIdAsync(1)).ReturnsAsync(produtoEsperado);

        var resultado = await _service.ObterPorIdAsync(1);

        Assert.NotNull(resultado);
        Assert.Equal("Mouse", resultado.Nome);
        Assert.Equal(1, resultado.Id);
    }

    [Fact]
    public async Task ObterPorId_RetornaNulo_QuandoIdNaoExistir()
    {
        _repositoryMock.Setup(r => r.ObterPorIdAsync(99)).ReturnsAsync((Produto?)null);

        var resultado = await _service.ObterPorIdAsync(99);

        Assert.Null(resultado);
    }
}