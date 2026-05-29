using TechProShop.TechProQuote.Domain.Entities;

namespace TechProShop.TechProQuote.Application.Interfaces;

/// <summary>
/// Abstraction du dépôt de clients. Définie dans la couche Application
/// (le contrat), implémentée dans Infrastructure (DIP — Jour 2, Module 8).
/// </summary>
public interface IClientRepository
{
    Task<Client?> GetByIdAsync(Guid id);
    Task<List<Client>> GetAllAsync();
    Task AddAsync(Client client);
}
