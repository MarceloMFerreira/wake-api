using Microsoft.EntityFrameworkCore;
using WakeCommerce.Api.Data;
using WakeCommerce.Api.Repositories;
using WakeCommerce.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona controllers tradicionais
builder.Services.AddControllers();

// Configuração do EF + SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=wakecommerce.db"));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//services
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

var app = builder.Build();

// Swagger só em desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilita controllers
app.MapControllers();

app.Run();