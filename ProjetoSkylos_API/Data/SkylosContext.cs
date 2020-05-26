using Microsoft.EntityFrameworkCore;
using ProjetoSkylos_API.Models;

namespace ProjetoSkylos_API.Data
{
    public class SkylosContext: DbContext
    {
     public SkylosContext(DbContextOptions<SkylosContext> options): base (options)
     {

     }

    public DbSet<Cliente> Cliente{get; set;}

    public DbSet<Cuidador> Cuidador{get; set;}

    public DbSet<Animal> Animal{get; set;}

    public DbSet<Avaliacao> Avaliacao{get; set;}

    public DbSet<Servico> Servico {get; set;}

    }
}