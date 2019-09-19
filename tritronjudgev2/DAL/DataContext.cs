using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class DataContext:IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<ProblemLanguage> ProblemLanguages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(p => p.ToTable("Users"));
            modelBuilder.Entity<ProblemLanguage>().HasKey(sc => new {sc.ProblemId, sc.LanguageId});
        }
    }

}