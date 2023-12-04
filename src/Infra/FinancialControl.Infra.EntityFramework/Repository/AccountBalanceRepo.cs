using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinancialControl.Domain.Interfaces.Repositories;
using FinancialControl.Domain.Models;
using FinancialControl.Infra.EntityFramework.DataModels;
using FinancialControl.Infra.EntityFramework.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialControl.Infra.EntityFramework.Repository
{
    public class AccountBalanceRepo : Repository<ApplicationDbContext, AccountBalanceModel, AccountBalanceDataModel>, IAccountBalanceRepo
    {
        public AccountBalanceRepo(IDbContextFactory<ApplicationDbContext> contextFactory, IMapper mapper) : base(contextFactory, mapper)
        {
        }

        public async Task<AccountBalanceModel> GetBalanceByDate(Guid accountId, DateTime date)
        {
            using var context = ConfigureContext();
            return await context.AccountBalances
                .Where(x => x.AccountId == accountId && x.UpdatedAt >= date && x.UpdatedAt <= date)
                .ProjectTo<AccountBalanceModel>(Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
