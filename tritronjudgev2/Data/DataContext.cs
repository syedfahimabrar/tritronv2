using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tritronAPI.Model;

namespace tritronAPI.Data
{
    public class DataContext:IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<Problem> Problems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(p => p.ToTable("Users"));
            modelBuilder.Entity<ContestProgrammingLanguage>()
                .HasKey(cp => new {cp.Contest_id, cp.ProgrammingLanguage_Id});
            modelBuilder.Entity<ContestProgrammingLanguage>().HasOne(cp => cp.ProgrammingLanguage)
                .WithMany(cp => cp.ContestProgrammingLanguages)
                .HasForeignKey(cp => cp.ProgrammingLanguage_Id);
            modelBuilder.Entity<ContestProgrammingLanguage>()
                .HasOne(cp => cp.Contest)
                .WithMany(cp => cp.ContestProgrammingLanguages)
                .HasForeignKey(cp => cp.Contest_id);
        }
    }

}