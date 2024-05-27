using Microsoft.EntityFrameworkCore;

namespace ProjectBD.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Measurement> Measurements { get; set; }
    }
}
