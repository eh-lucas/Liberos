using Liberos.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Liberos.Api.Data;

public class LiberosDbContext : IdentityDbContext
{
    public LiberosDbContext(DbContextOptions<LiberosDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            // Converte o nome da tabela para minúsculas
            entity.SetTableName(entity.GetTableName().ToLowerInvariant());

            // Converte os nomes das colunas para minúsculas
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName().ToLowerInvariant());
            }
        }
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Token> Tokens { get; set; }
    public DbSet<Content> Contents { get; set; }
    public DbSet<UserLibrary> UserLibrary { get; set; }
}

