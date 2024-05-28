﻿using CashFlow.Domain.Entities;
using CashFlow.Infrastructure.DataAccess.Maps;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess
{
    internal class CashFlowDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<User> Users { get; set; }  
        public DbSet<Peca> Pecas { get; set; }
        public DbSet<ValorPeca> ValoresPecas { get; set; }

        public CashFlowDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PecasMap());
            modelBuilder.ApplyConfiguration(new ValoresPecasMap()); 
        }
    }
}
