using FinancialControl.Domain.Interfaces.Base;
using FinancialControl.Domain.Models;
using System;

namespace FinancialControl.Domain.Interfaces.Repositories
{
    public interface ITransactionRepo : IRepository<TransactionModel, Guid>
    {

    }
}
