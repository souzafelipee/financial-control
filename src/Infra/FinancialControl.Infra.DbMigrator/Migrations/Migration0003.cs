using FluentMigrator;

namespace FinancialControl.Infra.DbMigrator.Migrations
{
    [Migration(3, BreakingChange = false)]
    public class Migration0003 : ForwardOnlyMigration
    {
        public override void Up()
        {

            Insert.IntoTable("Account_Balance").Row(new
            {
                account_id = "136CA601-5C9C-4AD1-8CAA-95289F1A6131",
                balance = 0,
                updated_at = DateTime.Now
            });
        }
    }
}
