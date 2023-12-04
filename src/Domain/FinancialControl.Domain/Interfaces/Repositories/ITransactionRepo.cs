using FinancialControl.Domain.Interfaces.Base;
using FinancialControl.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialControl.Domain.Interfaces.Repositories
{
    public interface ITransactionRepo : IRepository<TransactionModel, Guid>
    {
        Task<IEnumerable<TransactionModel>> GetByDate(Guid accountId, DateTime date);
    }
}
