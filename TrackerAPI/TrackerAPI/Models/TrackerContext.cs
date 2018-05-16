using Microsoft.EntityFrameworkCore;

namespace TrackerAPI.Models
{
    public class TrackerContext : DbContext
    {
        public TrackerContext(DbContextOptions<TrackerContext> options): base (options)
        { }

        public  DbSet<Bank> Banks { get; set; }
    }
}
