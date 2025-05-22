using MediaLibrary.Application.Interfaces;
using MediaLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Persistence;

public sealed class RepositoryDbContext : DbContext, IRepositoryDbContext
{
    public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options) : base(options) { }

    public DbSet<Group> Groups { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<VideoGame> VideoGames { get; set; }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(b =>
        {
            b.Property<Guid?>("GroupId");
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseSqlite("Data Source=sqlite.db");
        }
    }
}
