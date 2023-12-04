using System.Threading.Tasks;
using System;
using FinancialControl.Domain.Interfaces.Base;
using FinancialControl.Domain.Models;

namespace FinancialControl.Domain.Interfaces.Repositories
{
    public interface IAccountBalanceRepo: IRepository<AccountBalanceModel>
    {
        Task<AccountBalanceModel> GetBalanceByDate(Guid AccountId, DateTime date);
    }
}
