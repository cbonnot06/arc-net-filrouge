using System.Reflection.Metadata.Ecma335;
using TechProShop.TechProQuote.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddOpen





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
