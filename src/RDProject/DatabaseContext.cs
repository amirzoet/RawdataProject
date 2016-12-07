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
        //public DbSet<Post> posts { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<SearchId> sids { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Answer> answers { get; set; }
        public DbSet<Search> search { get; set; }
        public DbSet<Mark> mark { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySql("server=localhost;database=stackoverflow_sample_universal;uid=root;pwd=Loempia!3");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            modelBuilder.Entity<User>().Property(c => c.name).HasColumnName("displayname");
          
            modelBuilder.Entity<Comment>().Property(c => c.userid).HasColumnName("ownerid");
            modelBuilder.Entity<Answer>().Property(c => c.userid).HasColumnName("ownerid");

            modelBuilder.Entity<Mark>().HasKey(t => new {t.postid, t.userid });



            base.OnModelCreating(modelBuilder);
        }
    }
}
