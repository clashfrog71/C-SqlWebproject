using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using System.Data;
using System.Data.SqlClient;

using System.Diagnostics.CodeAnalysis;

namespace ScreenSound.Banco;

internal class ScreenSoundContext : DbContext
{
   private string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=ScreenSound;Integrated Security=True;";
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
    
    
}
