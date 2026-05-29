using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using TechProShop.TechProQuote.Application.Interfaces;
using TechProShop.TechProQuote.Domain.Entities;
using TechProShop.TechProQuote.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


var connectionString = builder.Configuration.GetConnectionString
    ("DefaultConnection")
    ?? @"Server=(localdb)\mssqllocaldb;Database=TechProQuote;Trusted_Connection=true;TrustServerCertificate=true";

builder.Services.AddDbContext<TechProQuoteDbContext>
    (opt => opt.UseSqlServer(connectionString));

builder.Services.AddScoped<IClientRepository, ClientRepository>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

// /api/clients

var apiClients = app.MapGroup("/api/clients");

apiClients.MapGet("/", () => new[]
        {
                new Client { Nom = "Alice Martin", Email = "alice@ex.com" },
                new Client { Nom = "Bob Durand", Email = "bob@ex.com" }
         }
);

apiClients.MapGet("/{id:guid}", (Guid id) =>
{
    return Results.Ok
    (
    new Client
    {
        Id = id,
        Nom = "Test",
        Email = "test@ex.com"
    });
});

apiClients.MapPost("/", (Client client) =>
    Results.Created($"/api.clients/{client.Id}", client));

app.Run();
