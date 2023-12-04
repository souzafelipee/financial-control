using AutoMapper;
using FinancialControl.Domain.Interfaces.Repositories;
using FinancialControl.Domain.Models;
using FinancialControl.Infra.EntityFramework.DataModels;
using FinancialControl.Infra.EntityFramework.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;

namespace FinancialControl.Infra.EntityFramework.Repository;
public class TransactionRepo : Repository<ApplicationDbContext, TransactionModel, TransactionDataModel, Guid>, ITransactionRepo
{
    public TransactionRepo(IDbContextFactory<ApplicationDbContext> contextFactory, IMapper mapper) 
        : base(contextFactory, mapper)
    {
    }
}
