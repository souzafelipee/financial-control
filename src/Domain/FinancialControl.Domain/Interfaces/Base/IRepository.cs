﻿using FinancialControl.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialControl.Domain.Interfaces.Base;

public interface IRepository<TDomainModel, TKey>
    where TDomainModel : IDomainModel<TKey>
    where TKey : IEquatable<TKey>
{
    Task<TDomainModel> Insert(TDomainModel domainModel);
    Task<TDomainModel> Update(TDomainModel domainModel);
    Task<TDomainModel> Get(TKey id);
    Task<IEnumerable<TDomainModel>> Get();
    Task Delete(TKey id);
}

public interface IRepository<TDomainModel> : IRepository<TDomainModel, int>
        where TDomainModel : DomainModel<int>
{
}