using FinancialControl.Infra.EntityFramework.DataModels.Base;
using System;
using System.Collections.Generic;

namespace FinancialControl.Infra.EntityFramework.DataModels
{
    public partial class AccountDataModel : DataModel<Guid>
    {
        public AccountDataModel()
        {
            AccountBalances = new HashSet<AccountBalanceDataModel>();
            Transactions = new HashSet<TransactionDataModel>();
        }

        public Guid AccountId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<AccountBalanceDataModel> AccountBalances { get; set; }
        public virtual ICollection<TransactionDataModel> Transactions { get; set; }
    }
}
