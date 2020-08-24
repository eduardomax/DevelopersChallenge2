using System;

namespace BankReconciliation.Domain.Common
{
    public abstract class Entity<T> where T : Entity<T>
    {
        public Guid Id { get; private set; }
    }
}
