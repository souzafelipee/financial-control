using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinancialControl.Domain.Interfaces.Repositories;
using FinancialControl.Domain.Models;
using FinancialControl.Infra.EntityFramework.DataModels;
using FinancialControl.Infra.EntityFramework.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialControl.Infra.EntityFramework.Repository;
public class TransactionRepo : Repository<ApplicationDbContext, TransactionModel, TransactionDataModel, Guid>, ITransactionRepo
{
    public TransactionRepo(IDbContextFactory<ApplicationDbContext> contextFactory, IMapper mapper) 
        : base(contextFactory, mapper)
    {
    }

    public async Task<IEnumerable<TransactionModel>> GetByDate(Guid accountId, DateTime date)
    {
        using var context = ConfigureContext();
        var transactions = await context.Transactions
            .Where(x => x.AccountId == accountId && x.TransactionDate >= date && x.TransactionDate < date.AddDays(1))
            .ProjectTo<TransactionModel>(Mapper.ConfigurationProvider)
            .ToListAsync();
        return transactions;
    }
}
