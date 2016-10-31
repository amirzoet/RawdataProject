using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RDProject.Domain_model;

namespace RDProject
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Post> posts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySql("server=localhost;database=stackoverflow_sample_universal;uid=root;pwd=Loempia!3");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("post");
            modelBuilder.Entity<Post>().Property(c => c.id).HasColumnName("id");
            modelBuilder.Entity<Post>().Property(c => c.creationdate).HasColumnName("creationdate");
            modelBuilder.Entity<Post>().Property(c => c.body).HasColumnName("body");
            modelBuilder.Entity<Post>().Property(c => c.score).HasColumnName("score");
            modelBuilder.Entity<Post>().Property(c => c.userid).HasColumnName("ownerid");

            base.OnModelCreating(modelBuilder);
        }
    }
}
