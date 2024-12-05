using DotnetTestCurrent.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetTestCurrent.Infrastructure;

public class DotnetTestCurrentDbContext : DbContext
{
    public DotnetTestCurrentDbContext(DbContextOptions<DotnetTestCurrentDbContext> options)
        : base(options) { }

    public DbSet<CustomerDbModel> Customers { get; set; }

    public DbSet<OrderDbModel> Orders { get; set; }

    public DbSet<AdrressDbModel> Adrresses { get; set; }
}
