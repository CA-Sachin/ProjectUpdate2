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
        //public DbSet<UserProject> UserProject{ get; set; }
        public DbSet<ProjectUpdate> ProjectUpdate{ get; set; }
        public DbSet<UserProjectUpdate> UserProjectUpdate{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserProject>()
            //    .HasKey(ur => new { ur.Id, ur.ProjectID });

            //modelBuilder.Entity<UserProject>()
            //    .HasOne(ur => ur.User)
            //    .WithMany(u => u.UserProjects)
            //    .HasForeignKey(ur => ur.Id);

            //modelBuilder.Entity<UserProject>()
            //    .HasOne(ur => ur.Project)
            //    .WithMany(r => r.UserProjects)
            //    .HasForeignKey(ur => ur.ProjectID);



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



            //modelBuilder.Entity<ProjectUpdate>()
            //   .HasKey(ur => new { ur.ProjectUpdateID});

            //modelBuilder.Entity<ProjectUpdate>()
            //    .HasOne<User>()
            //    .WithMany()
            //    .HasForeignKey(ur => ur.Id);

         




        }
    }
}
