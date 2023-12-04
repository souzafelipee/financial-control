using System;

namespace FinancialControl.Domain.Interfaces.Base;

public interface IDomainModel<TKey> where TKey : IEquatable<TKey>
{
    TKey Id { get; set; }
}
