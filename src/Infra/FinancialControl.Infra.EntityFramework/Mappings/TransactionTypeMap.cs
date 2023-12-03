using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FinancialControl.Infra.EntityFramework.DataModels;

namespace FinancialControl.Infra.EntityFramework.Mappings;

public class TransactionTypeMap : IEntityTypeConfiguration<TransactionTypeDataModel>
{
    public void Configure(EntityTypeBuilder<TransactionTypeDataModel> entity)
    {
        entity.ToTable("Transaction_Type");

        entity.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("transaction_type_id");

        entity.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnName("description");

    }
}
