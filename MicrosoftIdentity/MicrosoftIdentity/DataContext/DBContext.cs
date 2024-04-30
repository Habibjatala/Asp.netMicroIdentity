
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MicrosoftIdentity.Models;

namespace MicrosoftIdentity.DataContext
{
    public class DBContext : IdentityDbContext<ApplicationUser>
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }
     
  
        public DbSet<PersonalInfo> PersonalInfos { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonalInfo>()
         .HasOne(pi => pi.User)
         .WithMany(u => u.PersonalInfos)
         .HasForeignKey(pi => pi.UserId)
         .IsRequired();


            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.Id).HasColumnName("UserId");
        }
    }
}
