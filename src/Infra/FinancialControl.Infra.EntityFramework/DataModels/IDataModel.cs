using System;

namespace FinancialControl.Infra.EntityFramework.DataModels
{
    public interface IDataModel<TKey> where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}
