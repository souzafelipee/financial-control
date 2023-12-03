using FinancialControl.Infra.EntityFramework.DataModels.Base;
using System.Collections.Generic;

namespace FinancialControl.Infra.EntityFramework.DataModels
{
    public partial class TransactionTypeDataModel : DataModel
    {
        public TransactionTypeDataModel()
        {
            Transactions = new HashSet<TransactionDataModel>();
        }

        public string Description { get; set; }

        public virtual ICollection<TransactionDataModel> Transactions { get; set; }
    }
}
