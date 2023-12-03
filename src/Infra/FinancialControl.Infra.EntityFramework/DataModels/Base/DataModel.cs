using System;

namespace FinancialControl.Infra.EntityFramework.DataModels.Base;

public abstract class DataModel<TKey> : IDataModel<TKey>
    where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; }
}

public abstract class DataModel : DataModel<int>
{
}
