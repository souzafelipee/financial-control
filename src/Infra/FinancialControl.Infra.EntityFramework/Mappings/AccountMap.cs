using FinancialControl.Infra.EntityFramework.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialControl.Infra.EntityFramework.Mappings;

public class AccountMap : IEntityTypeConfiguration<AccountDataModel>
{
    public void Configure(EntityTypeBuilder<AccountDataModel> entity)
    {
        entity.ToTable("Account");

        entity.HasIndex(e => e.Id, "IX_Account_Balance_account_id");

        entity.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("account_id");

        entity.Property(e => e.Active).HasColumnName("active");

        entity.Property(e => e.CreatedAt)
            .HasColumnType("datetime")
            .HasColumnName("created_at");

        entity.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnName("description");
    }
}
