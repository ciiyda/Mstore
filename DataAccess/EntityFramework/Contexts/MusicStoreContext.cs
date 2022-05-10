using DataAccess.Configs;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework.Contexts
{
   public class MusicStoreContext: DbContext
    {
        public DbSet<Singer> Singers { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<UserDetails> UserDetail { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionConfig.ConnectionStirng);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>()
                .HasOne(a => a.Singer).WithMany(s => s.Albums).HasForeignKey(a=>a.SingerId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<City>()
               .HasOne(a => a.Country).WithMany(s => s.Cities).HasForeignKey(a=>a.CountryId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
            .HasOne(a => a.Role).WithMany(s => s.Users).HasForeignKey(a => a.RoleId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserDetails>()
            .HasOne(a => a.Country).WithMany(s => s.UserDetails).HasForeignKey(a => a.CountryId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserDetails>()
           .HasOne(a => a.City).WithMany(s => s.UserDetails).HasForeignKey(a => a.CityId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
          .HasOne(a => a.UserDetail).WithOne(s => s.User).HasForeignKey<User>(a => a.UserDetailsId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName).IsUnique();
            modelBuilder.Entity<UserDetails>()
                .HasIndex(u => u.Email).IsUnique();

        }
    }
}
