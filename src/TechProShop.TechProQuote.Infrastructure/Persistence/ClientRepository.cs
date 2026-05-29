using Microsoft.EntityFrameworkCore;
using TechProShop.TechProQuote.Application.Interfaces;
using TechProShop.TechProQuote.Domain.Entities;

namespace TechProShop.TechProQuote.Infrastructure.Persistence;

/// <summary>
/// Implémentation EF Core du dépôt de clients (Jour 2, Module 8).
/// </summary>
public class ClientRepository : IClientRepository
{
    private readonly TechProQuoteDbContext _ctx;

    public ClientRepository(TechProQuoteDbContext ctx) => _ctx = ctx;

    public async Task<Client?> GetByIdAsync(Guid id) =>
        await _ctx.Clients.FindAsync(id);

    public async Task<List<Client>> GetAllAsync() =>
        await _ctx.Clients.OrderBy(c => c.Nom).ToListAsync();

    public async Task AddAsync(Client client)
    {
        _ctx.Clients.Add(client);
        await _ctx.SaveChangesAsync();
    }
}
