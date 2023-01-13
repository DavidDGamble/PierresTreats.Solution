// Needed for accessing database

using Microsoft.EntityFrameworkCore;


namespace PierresTreats.Models 
{
  public class PierresTreatsContext : DbContext 
  {
    public DbSet<ClassName> ClassNames { get; set; }  // CHANGE CLASS NAME!!!

    public PierresTreatsContext(DbContextOptions options) : base(options) { } 
  }
}