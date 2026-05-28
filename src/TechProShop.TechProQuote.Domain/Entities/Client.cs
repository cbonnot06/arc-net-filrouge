using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TechProShop.TechProQuote.Domain.Entities
{
    public class Client
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Nom { get; init; }
        public required string Email { get; init; }
        public DateTime DateCreation { get; init; } = DateTime.UtcNow;

    }
}
