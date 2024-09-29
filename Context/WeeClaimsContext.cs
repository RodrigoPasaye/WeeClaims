using Microsoft.EntityFrameworkCore;
using WeeClaims.Models;

namespace WeeClaims.Context {
  public class WeeClaimsContext : DbContext {
    public WeeClaimsContext(DbContextOptions<WeeClaimsContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
  }
}
