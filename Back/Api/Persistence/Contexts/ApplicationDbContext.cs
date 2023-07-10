using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts
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

            modelBuilder.Entity<Event>()
                .HasMany(x => x.SocialNetworks)
                .WithOne(sn => sn.Event)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Speaker>()
                .HasMany(x => x.SocialNetworks)
                .WithOne(sn => sn.Speaker)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<EventAssignedSpeaker> EventsAssignedSpeakers { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }
    }
}
