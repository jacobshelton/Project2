using Microsoft.EntityFrameworkCore;
using GroupBox.Domain.Models;

namespace GroupBox.Data
{
  public class GroupBoxDbContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Password> Passwords { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("server=localhost;initial catalog=GroupBoxDb;user id=sa;password=Password12345;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>().HasKey(u => u.ID);
        builder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
        builder.Entity<User>().HasMany(u => u.Groups);

        builder.Entity<Password>().HasKey(p => p.ID);
        builder.Entity<Password>().HasIndex(p => p.Hash).IsUnique();

        builder.Entity<Group>().HasKey(g => g.ID);
        builder.Entity<Group>().HasIndex(g => g.Name).IsUnique();
        builder.Entity<Group>().HasMany(g => g.Users);

        builder.Entity<Post>().HasKey(p => p.ID);

    }
  }
}