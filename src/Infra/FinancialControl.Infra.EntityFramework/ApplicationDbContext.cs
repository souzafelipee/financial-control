using Microsoft.EntityFrameworkCore;
using FinancialControl.Infra.EntityFramework.DataModels;
using System.Reflection;

namespace FinancialControl.Infra.EntityFramework
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public virtual DbSet<AccountDataModel> Accounts { get; set; }
        public virtual DbSet<AccountBalanceDataModel> AccountBalances { get; set; }
        public virtual DbSet<TransactionDataModel> Transactions { get; set; }
        public virtual DbSet<TransactionTypeDataModel> TransactionTypes { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=financial-control;Uid=sa;Pwd=Senha@2023;");
        }
    }
}
