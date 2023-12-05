using FluentMigrator;

namespace FinancialControl.Infra.DbMigrator.Migrations
{
    [Migration(2, BreakingChange = false)]
    public class Migration0002 : ForwardOnlyMigration
    {
        public override void Up()
        {           

            Insert.IntoTable("Transaction_Type")
                .Row(new { transaction_type_id = 1, description = "Credit" });

            Insert.IntoTable("Transaction_Type")
                .Row(new { transaction_type_id = 2, description = "Debit" });

            Insert.IntoTable("Account")
                .Row(new
                {
                    account_id = "136CA601-5C9C-4AD1-8CAA-95289F1A6131",
                    description = "Conta Principal",
                    created_at = DateTime.UtcNow,
                    active = true
                });
        }
    }
}
