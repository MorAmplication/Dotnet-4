using DotnetTestCurrent.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetTestCurrent.Infrastructure;

public class DotnetTestCurrentDbContext : DbContext
{
    public DotnetTestCurrentDbContext(DbContextOptions<DotnetTestCurrentDbContext> options)
        : base(options) { }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Order> Orders { get; set; }
}
