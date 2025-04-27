using BarAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>(options =>
    options.UseSqlite("Data Source=bar.db")); // Configura o banco de Dados SQLite

builder.Services.AddControllers(); // Adiciona o serviço aos controllers.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Habilita o Swagger para documentação da API.

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita o Swagger apenas no ambiente de desenvolvimento.
    app.UseSwaggerUI(); // Interface para explorar e testar a API.
}

app.UseHttpsRedirection(); // Redireciona requisões HTTP para HTTPS
app.UseAuthorization();
app.MapControllers(); // Mapeia as rotas para os controllers da API.
app.Run();