using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrackerDB.Entities;

namespace TrackerDB
{
    public class TrackerDbContext : DbContext
    {
        string _connectionString = "Server=.;Database=TrackerDB;Trusted_Connection=True";
        public TrackerDbContext(DbContextOptions<TrackerDbContext> options) : base(options)
        { }

        public TrackerDbContext(string connectionString) : base()
        {
            if (!string.IsNullOrEmpty(connectionString))
                _connectionString = connectionString;
        }
        public TrackerDbContext() : base()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            //optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionCategory>(category =>
            {
                category.ToTable("TransactionCategory");
            });
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionCategory> TransactionCategories { get; set; }
        public DbSet<StoreDetails> StoreDetails { get; set; }


    }
}
