using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FinancialControl.Infra.EntityFramework.DataModels;

namespace FinancialControl.Infra.EntityFramework.Mappings;

public class TransactionMap : IEntityTypeConfiguration<TransactionDataModel>
{
    public void Configure(EntityTypeBuilder<TransactionDataModel> entity)
    {
        entity.ToTable("Transaction");

        entity.HasIndex(e => e.AccountId, "IX_Transaction_account_id");

        entity.HasIndex(e => e.TransactionTypeId, "IX_Transaction_transaction_type_id");

        entity.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("transaction_id");

        entity.Property(e => e.AccountId).HasColumnName("account_id");

        entity.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnName("description");

        entity.Property(e => e.TransactionDate)
            .HasColumnType("datetime")
            .HasColumnName("transaction_date");

        entity.Property(e => e.TransactionTypeId).HasColumnName("transaction_type_id");

        entity.Property(e => e.Value)
            .HasColumnType("decimal(18, 2)")
            .HasColumnName("value");

        entity.HasOne(d => d.Account)
            .WithMany(p => p.Transactions)
            .HasForeignKey(d => d.AccountId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Transaction_account_id_Account_account_id");

        entity.HasOne(d => d.TransactionType)
            .WithMany(p => p.Transactions)
            .HasForeignKey(d => d.TransactionTypeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Transaction_transaction_type_id_Transaction_Type_transaction_type_id");

    }
}
