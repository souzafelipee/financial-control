using System;

namespace FinancialControl.Infra.EntityFramework.DataModels.Base
{
    public interface IDataModel<TKey> where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}
