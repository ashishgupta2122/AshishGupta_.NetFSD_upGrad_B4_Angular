using Microsoft.EntityFrameworkCore;
using EMS.DAL.Models;

namespace EMS.DAL.Data
{
    public class EMSDbContext : DbContext
    {
        public EMSDbContext(DbContextOptions<EMSDbContext> options) : base(options)
        {
        }

        public DbSet<UserInfo> Users
        {
            get;
            set;
        }

        public DbSet<EventDetails> Events
        {
            get;
            set;
        }

        public DbSet<SpeakersDetails> Speakers
        {
            get;
            set;
        }

        public DbSet<SessionInfo> Sessions
        {
            get;
            set;
        }

        public DbSet<ParticipantEventDetails> ParticipantEvents
        {
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SessionInfo>()
                .HasOne(s => s.Event)
                .WithMany()
                .HasForeignKey(s => s.EventId);

            modelBuilder.Entity<SessionInfo>()
                .HasOne(s => s.Speaker)
                .WithMany()
                .HasForeignKey(s => s.SpeakerId);
        }
    }
}