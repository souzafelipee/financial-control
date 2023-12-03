using FinancialControl.Infra.EntityFramework.DataModels.Base;
using System;

namespace FinancialControl.Infra.EntityFramework.DataModels
{
    public partial class TransactionDataModel : DataModel<Guid>
    {
        public Guid AccountId { get; set; }
        public int TransactionTypeId { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime TransactionDate { get; set; }

        public virtual AccountDataModel Account { get; set; }
        public virtual TransactionTypeDataModel TransactionType { get; set; }
    }
}
