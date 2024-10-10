using ApiDataBaseFirst.Repository;
using ApiDataBaseFirst.Repository.Interfaces;
using ApiDataBaseFirst.DataBaseContext; // Ajoute l'espace de noms de ton DbContext
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore; // Nécessaire pour les options du DbContext

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enregistre le DbContext avec la chaîne de connexion
builder.Services.AddDbContext<OnlineStoreDBContext>(options =>
    options.UseSqlServer("Data source=(localdb)\\MSSQLLocalDB;initial catalog=OnlineStore;user id=sa;password=ideal2s;Trust Server Certificate=True"));

// Enregistre le repository avec l'interface correcte
builder.Services.AddScoped<ICustomerRepostory, CustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

