using Microsoft.EntityFrameworkCore;
using EMS.DAL.Models;

namespace EMS.DAL.Data
{
    public class EMSDbContext : DbContext
    {
        public EMSDbContext(DbContextOptions<EMSDbContext> options) : base(options)
        {
        }

        public DbSet<UserInfo> UserInfos
        {
            get;
            set;
        }

        public DbSet<EventDetails> EventDetails
        {
            get;
            set;
        }

        public DbSet<SpeakersDetails> SpeakersDetails
        {
            get;
            set;
        }

        public DbSet<SessionInfo> SessionInfos
        {
            get;
            set;
        }

        public DbSet<ParticipantEventDetails> ParticipantEventDetails
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