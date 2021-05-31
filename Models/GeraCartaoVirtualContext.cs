using Microsoft.EntityFrameworkCore;

namespace VaiVoa.Models
{
  public class GeraCartaoVirtualContext : DbContext
  {
    public GeraCartaoVirtualContext(DbContextOptions<GeraCartaoVirtualContext> options) : base(options)
    {
    }

    public DbSet<GeraCartaoVirtual> GeraCartaoVirtual { get; set; }
  }
}
