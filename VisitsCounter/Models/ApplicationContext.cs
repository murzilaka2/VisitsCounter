using Microsoft.EntityFrameworkCore;

namespace VisitsCounter.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> context) : base(context)
        {

        }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
