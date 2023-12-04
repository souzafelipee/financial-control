using FinancialControl.Domain.Interfaces.Base;
using System;

namespace FinancialControl.Domain.Models.Base
{
    public abstract class DomainModel<TKey> : IDomainModel<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }

    public abstract class DomainModel : DomainModel<int>
    {

    }
}
