using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<EventAssignedSpeaker>().HasKey(x => new { x.EventId, x.SpeakerId });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<EventAssignedSpeaker> EventsAssignedSpeakers { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }
    }
}
