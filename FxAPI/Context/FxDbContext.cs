using FxAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FxAPI.Context
{
    public class FxDbContext:DbContext
    {
        public FxDbContext(DbContextOptions<FxDbContext> options) : base(options)
        {

        }
        public DbSet<Currency> Currency { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().ToTable("currency");
        }
    }
}
