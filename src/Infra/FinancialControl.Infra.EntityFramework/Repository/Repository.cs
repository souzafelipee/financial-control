using AutoMapper;
using FinancialContraol.Domain.Models;
using FinancialControl.Infra.EntityFramework.DataModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace FinancialControl.Infra.EntityFramework.Repository
{
    public abstract class Repository<TContext, TDomainModel, TDataModel, TKey> 
        : RepositoryBase<TContext, TDomainModel, TDataModel, TKey>
        where TContext: DbContext
        where TDomainModel: DomainModel<TKey>
        where TDataModel : DataModel<TKey>
        where TKey : IEquatable<TKey>
    {
        protected Repository(IDbContextFactory<TContext> contextFactory, IMapper mapper) 
            : base(contextFactory, mapper) { }

        protected override TContext ConfigureContext()
        {
            return ContextFactory.CreateDbContext();
        }

        protected override TDataModel MapDomainToDataModel(TDomainModel domainModel)
        {
            return Mapper.Map<TDataModel>(domainModel);
        }
    }

    public abstract class Repository<TContext, TDomainModel, TDataModel> : Repository<TContext, TDomainModel, TDataModel, int>
        where TContext : DbContext
        where TDomainModel : DomainModel
        where TDataModel : DataModel
    {
        protected Repository(IDbContextFactory<TContext> contextFactory, IMapper mapper) :
            base(contextFactory, mapper)
        {
        }
    }

    public abstract class Repository<TDomainModel, TDataModel> : Repository<DbContext, TDomainModel, TDataModel, int>
        where TDomainModel : DomainModel
        where TDataModel : DataModel
    {
        protected Repository(IDbContextFactory<DbContext> contextFactory, IMapper mapper) :
            base(contextFactory, mapper)
        {
        }
    }
}
