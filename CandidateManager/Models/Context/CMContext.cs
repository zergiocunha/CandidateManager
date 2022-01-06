using Microsoft.EntityFrameworkCore;
using GestorDeCandidatos.Models;

namespace CandidateManager.Models.Context
{
    public class CMContext : DbContext
    {
        public CMContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidateExperience>()
                .HasOne<Candidate>()
                .WithMany()
                .HasForeignKey(p => p.IdCandidate);

            modelBuilder.Entity<Candidate>()
                .HasIndex(p => p.Email).IsUnique();

        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateExperience> CandidateExperiences { get; set; }
    }
}
