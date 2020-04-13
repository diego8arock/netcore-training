using System;

namespace Training.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void CommitChanges();
        void RollbackChanges();
    }
}