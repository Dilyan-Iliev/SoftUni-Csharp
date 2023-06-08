namespace TaskboardApp.Data;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskboardApp.Data.Entities;
using TaskboardApp.Data.Entities.Configuration;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<TaskEntity> Tasks { get; set; }

    public DbSet<Board> Boards { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new BoardConfiguration());
        builder.ApplyConfiguration(new TaskConfiguration());

        base.OnModelCreating(builder);
    }
}