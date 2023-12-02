using FinancialContraol.Domain.Interfaces;
using System;

namespace FinancialContraol.Domain.Models
{
    public abstract class DomainModel<TKey> : IDomainModel<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }

    public abstract class DomainModel : DomainModel<int>
    {

    }
}
