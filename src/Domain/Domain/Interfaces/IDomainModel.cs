using System;

namespace FinancialContraol.Domain.Interfaces;

public interface IDomainModel<TKey> where TKey : IEquatable<TKey>
{
    TKey Id { get; set; }
}
