using Microsoft.EntityFrameworkCore;
using ProjectUpdateApp.Models;

namespace ProjectUpdateApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
       
        public DbSet<User> User { get; set; }
      
        public DbSet<ProjectUpdate> ProjectUpdate{ get; set; }
        public DbSet<UserProjectUpdate> UserProjectUpdate{ get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<UserProject> UserProject{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           



            modelBuilder.Entity<UserProjectUpdate>()
                .HasKey(ur => new { ur.ProjectUpdateID, ur.Id });

            modelBuilder.Entity<UserProjectUpdate>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserProjectUpdates)
                .HasForeignKey(ur => ur.Id);

            modelBuilder.Entity<UserProjectUpdate>()
                .HasOne(ur => ur.ProjectUpdate)
                .WithMany(r => r.UserProjectUpdates)
                .HasForeignKey(ur => ur.ProjectUpdateID);



         




        }
    }
}
