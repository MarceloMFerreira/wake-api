using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WakeCommerce.Api.Entities;

namespace WakeCommerce.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Produto> Produtos => Set<Produto>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>().HasData(
            new Produto { Id = 1, Nome = "Teclado", Estoque = 10, Valor = 259.90m },
            new Produto { Id = 2, Nome = "Mouse", Estoque = 25, Valor = 120.00m },
            new Produto { Id = 3, Nome = "Monitor", Estoque = 5, Valor = 899.00m },
            new Produto { Id = 4, Nome = "Headset", Estoque = 15, Valor = 199.90m },
            new Produto { Id = 5, Nome = "Webcam", Estoque = 8, Valor = 350.00m }
        );
    }
}