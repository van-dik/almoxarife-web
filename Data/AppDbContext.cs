using Microsoft.EntityFrameworkCore;
using SistemaAlmoxarifado.Models;

namespace SistemaAlmoxarifado.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Solicitacao> Solicitacoes { get; set; }
}
