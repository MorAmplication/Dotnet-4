using Dotnet_4.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_4.Infrastructure;

public class Dotnet_4DbContext : DbContext
{
    public Dotnet_4DbContext(DbContextOptions<Dotnet_4DbContext> options)
        : base(options) { }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Order> Orders { get; set; }
}
