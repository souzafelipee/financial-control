using FinancialControl.Infra.EntityFramework.DataModels.Base;
using System;

namespace FinancialControl.Infra.EntityFramework.DataModels
{
    public partial class AccountBalanceDataModel : DataModel
    {
        public Guid AccountId { get; set; }
        public decimal Balance { get; set; }
        public DateTime BalanceDate { get; set; }

        public virtual AccountDataModel Account { get; set; }
    }
}
