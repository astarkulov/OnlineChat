using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineChat.DataAccessLayer.Common
{
    public interface IReadOnlyUnitOfWork : IDisposable
    {
        DbContext GetContext();

        IReadOnlyGenericRepository<TEntity> GetCommonRepository<TEntity>() where TEntity : class;
    }

    public interface IReadOnlyUnitOfWork<out TContext> : IReadOnlyUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }

    public interface IUnitOfWork : IReadOnlyUnitOfWork
    {
        new IGenericRepository<TEntity> GetCommonRepository<TEntity>() where TEntity : class;

        void Save();

        Task SaveAsync();
    }

    public interface IUnitOfWork<out TContext> : IUnitOfWork, IReadOnlyUnitOfWork<TContext> where TContext : DbContext
    {
    }
}
