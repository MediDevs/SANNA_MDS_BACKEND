using MDS.Dto;
using MDS.Dto.List;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Infrastructure.DbUtility
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }

        bool HasChanges();
        bool IsInTransaction();
        void ExecuteInTransaction(Action action);
        // void RollbackTransaction();
        void ClearChangeTracker();

        Task ClearDb(params string[] excluded);
        Task TruncateTables(params string[] tables);

        void Commit();
        Task CommitAsync();
        Task CommitAsync(bool skipCacheUpdate);

        IQueryable<T> Query<T>() where T : class, IEntity;
        IQueryable<T> Query<T>(Expression<Func<T, bool>> filter) where T : class, IEntity;
        IQueryable<T> GetQueryable<T>() where T : class, IEntity;

        Task<List<T>> ExecuteStoredProcAll<T>(string storedProcName) where T : class;
        Task<T> ExecuteStoredProcObjectByParam<T>(string storedProcName, SqlParameter[] procParams) where T : class;
        Task<List<T>> ExecuteStoredProcByParam<T>(string storedProcName, SqlParameter[] procParams) where T : class;
        Task<TablaPaginacionList> ExecuteStoredProcPagination<T>(string storedProcName, SqlParameter[] procParams, int skip, int pageSize) where T : class;
        Task<int> ExecuteStoredProcReturnValue(string storedProcName, SqlParameter[] procParams);

        Task ExecuteInTransactionAsync(Func<Task> action);
    }

    public interface IUnitOfWork<T> : IUnitOfWork, IDisposable where T : DbContext
    { }
}
