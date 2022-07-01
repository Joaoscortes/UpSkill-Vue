using System;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Persistence
{
    public class SqliteDB : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Filename=db/database.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Note>().ToTable("Notes");
        }
    }
}
