using FinancialControl.Infra.EntityFramework.DataModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FinancialControl.Infra.EntityFramework.Mappings;

public class AccountBalanceMap : IEntityTypeConfiguration<AccountBalanceDataModel>
{
    public void Configure(EntityTypeBuilder<AccountBalanceDataModel> entity)
    {
        entity.ToTable("Account_Balance");

        entity.Property(e => e.Id).HasColumnName("account_balance_id");

        entity.Property(e => e.AccountId).HasColumnName("account_id");

        entity.Property(e => e.Balance)
            .HasColumnType("decimal(18, 2)")
            .HasColumnName("balance");

        entity.Property(e => e.UpdatedAt)
            .HasColumnType("datetime")
            .HasColumnName("updated_at");

        entity.HasOne(d => d.Account)
            .WithMany(p => p.AccountBalances)
            .HasForeignKey(d => d.AccountId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Account_Balance_account_id_Account_account_id");

    }
}
