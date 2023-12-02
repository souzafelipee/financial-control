using AutoMapper;
using FinancialContraol.Domain.Interfaces;
using FinancialContraol.Domain.Models;
using FinancialControl.Infra.EntityFramework.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialControl.Infra.EntityFramework.Repository;

public abstract class RepositoryBase<TContext, TDomainModel, TDataModel, TKey> : IRepository<TDomainModel, TKey>
    where TContext : DbContext
    where TDomainModel : DomainModel<TKey>
    where TDataModel : DataModel<TKey>
    where TKey : IEquatable<TKey>
{
    protected IDbContextFactory<TContext> ContextFactory { get; }
    protected IMapper Mapper { get; }
    protected RepositoryBase(IDbContextFactory<TContext> _contextFactory, IMapper mapper)
    {
        ContextFactory = _contextFactory;
        Mapper = mapper;
    }

    protected abstract TContext ConfigureContext();
    protected abstract TDataModel MapDomainToDataModel(TDomainModel domainModel);

    public virtual async Task<TDomainModel> Insert(TDomainModel domainModel)
    {
        var dataModel = MapDomainToDataModel(domainModel);
        using var context = ConfigureContext();

        context.Set<TDataModel>().Add(dataModel);
        await context.SaveChangesAsync();
        return Mapper.Map(dataModel, domainModel);
    }

    public virtual async Task<TDomainModel> Update(TDomainModel domainModel)
    {
        var dataModel = MapDomainToDataModel(domainModel);
        using var context = ConfigureContext();

        context.Set<TDataModel>().Update(dataModel);
        await context.SaveChangesAsync();
        return Mapper.Map(dataModel, domainModel);
    }

    public virtual async Task<TDomainModel> Get(TKey id)
    {
        using var context = ConfigureContext();
        var dataModel = await context.Set<TDataModel>().FindAsync(id);

        return Mapper.Map<TDomainModel>(dataModel);
    }

    public virtual async Task<IEnumerable<TDomainModel>> Get()
    {
        using var context = ConfigureContext();
        var dataModels = await context.Set<TDataModel>().ToListAsync();

        return Mapper.Map<IEnumerable<TDomainModel>>(dataModels);
    }

    public virtual async Task Delete(TKey id)
    {
        using var context = ConfigureContext();
        var dbSet = context.Set<TDataModel>();
        var dataModel = await dbSet.FindAsync(id);

        dbSet.Remove(dataModel);
        await context.SaveChangesAsync();
    }
}