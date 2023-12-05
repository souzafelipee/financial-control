using FluentMigrator;


namespace FinancialControl.Infra.DbMigrator
{
    [Migration(1)]
    public class Baseline: AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Transaction_Type")
                .WithColumn("transaction_type_id")
                    .AsInt32()
                    .PrimaryKey()
                .WithColumn("description")
                    .AsString(size: 255)
                    .NotNullable();

            Create.Table("Account")
                .WithColumn("account_id")
                    .AsGuid()
                    .PrimaryKey()
                .WithColumn("description")
                    .AsString(size: 255)
                    .NotNullable()
                .WithColumn("created_at")
                    .AsDateTime()
                    .NotNullable()
                .WithColumn("active")
                    .AsBoolean()
                    .NotNullable();

            Create.Table("Transaction")
                .WithColumn("transaction_id")
                    .AsGuid()
                    .PrimaryKey()
                .WithColumn("account_id")
                    .AsGuid()
                    .NotNullable()
                    .ForeignKey(primaryTableName: "Account", primaryColumnName: "account_id")
                .WithColumn("transaction_type_id")
                    .AsInt32()
                    .NotNullable()
                    .ForeignKey(primaryTableName: "Transaction_Type", primaryColumnName: "transaction_type_id")
                .WithColumn("description")
                    .AsString(size: 255)
                    .NotNullable()
                .WithColumn("value")
                    .AsDecimal(18,2)
                    .NotNullable()
                .WithColumn("transaction_date")
                    .AsDateTime()
                    .NotNullable();

            Create.Table("Account_Balance")
                .WithColumn("account_balance_id")
                    .AsInt32()
                    .PrimaryKey()
                    .Identity()
                .WithColumn("account_id")
                    .AsGuid()
                    .NotNullable()
                    .ForeignKey(primaryTableName: "Account", primaryColumnName: "account_id")
                .WithColumn("balance")
                    .AsDecimal(18, 2)
                    .NotNullable()
                .WithColumn("balance_date")
                    .AsDateTime()
                    .NotNullable();

            Create.Index("IX_Transaction_account_id")
                .OnTable("Transaction").InSchema("dbo")
                .OnColumn("account_id").Ascending();

            Create.Index("IX_Transaction_transaction_type_id")
                .OnTable("Transaction").InSchema("dbo")
                .OnColumn("transaction_type_id").Ascending();

            Create.Index("IX_Account_Balance_account_id")
                .OnTable("Account").InSchema("dbo")
                .OnColumn("account_id").Ascending();


        }

    }
}