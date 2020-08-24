using BankReconciliation.Domain.Transactions;
using BankReconciliation.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BankReconciliation.Infrastructure.Context
{
    public class TransactionContext : DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        }
    }
}
