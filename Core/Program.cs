using Microsoft.EntityFrameworkCore;
using Models.DbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// postgres
var dbStringPGSQL = builder.Configuration.GetConnectionString("DefaultConnection");
try {
// banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options
        .UseNpgsql(dbStringPGSQL)
);
} catch (Exception ex)
{
    Console.WriteLine($"Erro ao configurar o banco de dados: {ex.Message}");
    throw;
}
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/openapi/v1.json", "v1");
        });
    
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();