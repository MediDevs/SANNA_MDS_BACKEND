using MDS.Utility.Exceptions;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MDS.Utility.Extensions;
using MDS.Infrastructure.Events;
using MDS.Dto;
using Newtonsoft.Json;
using System.Runtime.InteropServices.JavaScript;
using System.Collections;
using Microsoft.Data.SqlClient;
using MDS.Dto.List;

namespace MDS.Infrastructure.DbUtility
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;

        public DbContext Context { get; private set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public UnitOfWork(DbContext context)
        {
            context.EnsureNotNull();
            Context = context;
        }

        /// <summary>
        ///     Occurs when an entity is updated.
        /// </summary>
        public event EventHandler<EntityEventArgs> EntityUpdated;

        /// <summary>
        ///     Determines whether the unit of work is in a transaction.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if the unit is part of a transaction.
        /// </returns>
        public bool IsInTransaction()
        {
            return _transaction != null;
        }

        /// <summary>
        ///     Executes the action in a transaction.
        /// </summary>
        /// <param name="action">The action that needs to be wrapped in a transaction.</param>
        public void ExecuteInTransaction(Action action)
        {
            var isAlreadyInTransaction = IsInTransaction();

            try
            {
                if (!isAlreadyInTransaction) BeginTransaction();
                action();
                if (!isAlreadyInTransaction) CommitTransaction();
            }
            catch (Exception)
            {
                if (!isAlreadyInTransaction)
                    RollbackTransaction();
                throw;
            }
        }

        /// <summary>
        ///     Determines whether this instance has changes.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if unit of work has changes for the database.
        /// </returns>
        public bool HasChanges()
        {
            return GetChanges().Any();
        }

        public async Task CommitAsync()
        {
            await CommitAsync(true);
        }

        /// <summary>
        ///     Saves the changes.
        /// </summary>
        /// <exception cref="AppException">SaveChanges failed:\r\n{0} \r\n {1}</exception>
        public async Task CommitAsync(bool skipCacheUpdate)
        {
            try
            {
                // collect entries to fire events after save changes
                var modifiedEntries = !skipCacheUpdate ? GetChanges().ToArray() : null;

                await Context.SaveChangesAsync();

                // fire entries updated
                if (modifiedEntries != null && modifiedEntries.Any() && EntityUpdated != null)
                {
                    var modifiedTypes = modifiedEntries.Select(e => e.GetType()).Distinct().ToArray();
                    EntityUpdated(this, new EntityEventArgs(modifiedTypes));
                }
            }
            catch (DbUpdateException ex)
            {
                if (IsInTransaction())
                    RollbackTransaction();

                TryRejectChanges();
                throw new AppException("SaveChanges failed", ex);
            }
        }


        /// <summary>
        ///     Deletes all tables from the database.
        /// </summary>
        public async Task ClearDb(params string[] excluded)
        {
            /*
             * Whole idea for this was taken from:
             * - Initial read here: https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/advanced?view=aspnetcore-3.1
             * - Problem with exceptions here: https://stackoverflow.com/questions/41935752/entity-framework-core-how-to-get-the-connection-from-the-dbcontext (comment by Nicola Prada
             * - Then solution and clearer picture I got from here: https://www.learnentityframeworkcore.com/raw-sql
             */

#if (STAGING || RELEASE)
                throw new Exception("Clearing a production database is not allowed!");
#endif

            // Context.Database.ExecuteSqlRaw() // Works only on tables and procedures

            /* Code in region below works, but I have little to no control to dispose stuff.
             * Leaving it here as it is code that helped me figure out what is wrong with query below. 
             * HINT! Don't escape characters in the SQL query. */
            #region Development stuff
            //await using (var command = Context.Database.GetDbConnection().CreateCommand())
            //{
            //    command.CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME <> '__MigrationHistory' AND TABLE_NAME <> '__EFMigrationsHistory' AND TABLE_NAME <> 'sysdiagrams'";
            //    Context.Database.OpenConnection();
            //    await using (var result = command.ExecuteReader())
            //    {
            //        // do something with result
            //        var tableNames = new List<string>();
            //        if (result.HasRows)
            //        {
            //            while (await result.ReadAsync())
            //            {
            //                //var row = new EnrollmentDateGroup { EnrollmentDate = reader.GetDateTime(0), StudentCount = reader.GetInt32(1) };
            //                //groups.Add(row);
            //                tableNames.Add(result.GetString(0));
            //            }
            //        }
            //    }
            //}
            #endregion

            var conn = Context.Database.GetDbConnection();
            try
            {
                await conn.OpenAsync();
                var tableNames = new List<string>();

                await using (var command = conn.CreateCommand())
                {
                    command.CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME <> '__MigrationHistory' AND TABLE_NAME <> '__EFMigrationsHistory' AND TABLE_NAME <> 'sysdiagrams'"; ;
                    DbDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            tableNames.Add(reader.GetString(0));
                        }
                    }
                    reader.Dispose();
                }


                tableNames = tableNames.Where(name => excluded == null || !excluded.Contains(name)).ToList();

                foreach (var tableName in tableNames)
                    await conn.ExecuteSqlCommand($"ALTER TABLE {tableName} NOCHECK CONSTRAINT ALL");
                foreach (var tableName in tableNames)
                    await conn.ExecuteSqlCommand($"DELETE FROM {tableName}; DBCC CHECKIDENT ({tableName}, RESEED, 0)");
                foreach (var tableName in tableNames)
                    await conn.ExecuteSqlCommand($"ALTER TABLE {tableName} CHECK CONSTRAINT ALL");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message, e.InnerException);
            }
            finally
            {
                conn.Close();
            }
        }

        public async Task TruncateTables(params string[] tables)
        {
#if (STAGING || RELEASE)
                throw new Exception("Truncating production tables is not allowed!");
#endif
            var conn = Context.Database.GetDbConnection();
            try
            {
                await conn.OpenAsync();
                var tableNames = new List<string>();

                await using (var command = conn.CreateCommand())
                {
                    command.CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME <> '__MigrationHistory' AND TABLE_NAME <> '__EFMigrationsHistory' AND TABLE_NAME <> 'sysdiagrams'"; ;
                    DbDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            tableNames.Add(reader.GetString(0));
                        }
                    }
                    reader.Dispose();
                }

                tableNames = tableNames.Where(name => tables.Contains(name)).ToList();

                foreach (var tableName in tableNames)
                    await conn.ExecuteSqlCommand($"ALTER TABLE {tableName} NOCHECK CONSTRAINT ALL");
                foreach (var tableName in tableNames)
                    await conn.ExecuteSqlCommand($"DELETE FROM {tableName}; DBCC CHECKIDENT ({tableName}, RESEED, 0)");
                foreach (var tableName in tableNames)
                    await conn.ExecuteSqlCommand($"ALTER TABLE {tableName} CHECK CONSTRAINT ALL");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message, e.InnerException);
            }
            finally
            {
                conn.Close();
            }
        }

        public void Commit()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                if (IsInTransaction())
                    RollbackTransaction();

                TryRejectChanges();
                throw new AppException("SaveChanges failed", ex);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            if (IsInTransaction())
                RollbackTransaction();

            if (Context == null)
                return;

            Context.Dispose();
            Context = null;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }


        /// <summary>
        ///     Gets the queryable of <typeparamref name="T" /> of the database.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <returns>
        ///     A query
        /// </returns>
        public IQueryable<T> GetQueryable<T>() where T : class, IEntity
        {
            return Context.Set<T>().AsQueryable();
        }

        private void BeginTransaction()
        {
            if (IsInTransaction())
                throw new AppException("Already in transaction.");

            _transaction = Context.Database.BeginTransaction();
        }

        private void CommitTransaction()
        {
            if (!IsInTransaction())
                throw new AppException("Not in transaction.");

            _transaction.Commit();
            _transaction.Dispose();
            _transaction = null;

            ClearChangeTracker();
        }

        private void RollbackTransaction()
        {
            if (!IsInTransaction())
                throw new AppException("Not in transaction");

            _transaction.Rollback();
            _transaction.Dispose();
            _transaction = null;

            ClearChangeTracker();
        }

        private void TryRejectChanges()
        {
            try
            {
                foreach (var entry in Context.ChangeTracker.Entries())
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entry.CurrentValues.SetValues(entry.OriginalValues);
                            entry.State = EntityState.Unchanged;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Unchanged;
                            break;
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("TryRejectChanges silently failed: {0}", ex.Message);
            }
        }

        private IEnumerable<object> GetChanges()
        {
            return Context.ChangeTracker.Entries()
                .Where(t =>
                    t.State == EntityState.Added || t.State == EntityState.Modified ||
                    t.State == EntityState.Deleted)
                .Select(e => e.Entity);
        }

        public IQueryable<T> Query<T>() where T : class, IEntity
        {
            return Context.Set<T>();
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> filter) where T : class, IEntity
        {
            return Context.Set<T>().Where(filter);
        }

        public async Task<List<T>> ExecuteStoredProcAll<T>(string storedProcName) where T : class
        {
            DbConnection conn = Context.Database.GetDbConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    await conn.OpenAsync();

                await using (DbCommand command = conn.CreateCommand())
                {
                    if (IsInTransaction())
                    {
                        command.Transaction = Context.Database.CurrentTransaction.GetDbTransaction();
                    }

                    command.CommandText = storedProcName;
                    command.CommandType = CommandType.StoredProcedure;

                    DbDataReader reader = await command.ExecuteReaderAsync();


                    List<T> objList = new List<T>();
                    IEnumerable<PropertyInfo> props = typeof(T).GetRuntimeProperties();
                    Dictionary<string, DbColumn> colMapping = reader.GetColumnSchema()
                        .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
                        .ToDictionary(key => key.ColumnName.ToLower());

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            T obj = Activator.CreateInstance<T>();
                            foreach (PropertyInfo prop in props)
                            {
                                object val =
                                    reader.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                                prop.SetValue(obj, val == DBNull.Value ? null : val);
                            }
                            objList.Add(obj);
                        }
                    }
                    reader.Dispose();

                    return objList;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message, e.InnerException);
            }
            finally
            {
                conn.Close();
            }

            return null; // default state
        }
        public async Task<TablaPaginacionList> ExecuteStoredProcPagination<T>(string storedProcName, SqlParameter[] procParams, int skip, int pageSize) where T : class
        {
            DbConnection conn = Context.Database.GetDbConnection();
            //int response = 0;
            int respuestaTotal = 0;

            try
            {
                if (conn.State != ConnectionState.Open)
                    await conn.OpenAsync();

                await using (DbCommand command = conn.CreateCommand())
                {
                    if (IsInTransaction())
                    {
                        command.Transaction = Context.Database.CurrentTransaction.GetDbTransaction();
                    }

                    command.CommandText = storedProcName;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(procParams);

                    //var menu = new List<object>();
                    var listaResultados = new List<object>();

                    using (DbDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync()) 
                        {
                            //response = (int)reader["TOTAL"];
                            respuestaTotal = (int)reader["TOTAL"];
                        }

                        reader.NextResult();

                        while (await reader.ReadAsync())
                        {
                            IEnumerable<PropertyInfo> props = typeof(T).GetRuntimeProperties();
                            Dictionary<string, DbColumn> colMapping = reader.GetColumnSchema()
                                .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
                                .ToDictionary(key => key.ColumnName.ToLower());

                            T obj = Activator.CreateInstance<T>();

                            foreach (PropertyInfo prop in props)
                            {
                                object val =
                                    reader.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                                prop.SetValue(obj, val == DBNull.Value ? null : val);
                            }
                            //menu.Add(obj);
                            listaResultados.Add(obj);   
                        }                    
                            reader.Dispose();   
                    }
                    /*var tablaPaginacionList = new TablaPaginacionList();
                    tablaPaginacionList.TotalCount = response;
                    tablaPaginacionList.PageSize = pageSize;
                    tablaPaginacionList.Skip = skip;
                    tablaPaginacionList.TotalPages = (int)Math.Ceiling(response / (double)pageSize);
                    tablaPaginacionList.Result = menu;*/

                    TablaPaginacionList tablaPaginacionList = new TablaPaginacionList()
                    {
                        TotalCount = respuestaTotal,
                        PageSize = pageSize,
                        Skip = skip,
                        TotalPages = (int)Math.Ceiling(respuestaTotal/(double)pageSize),
                        Result = listaResultados
                    };

                    return tablaPaginacionList;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message, e.InnerException);
            }
            finally
            {
                conn.Close();
            }

            return null; // default state
        }

        public async Task<List<T>> ExecuteStoredProcByParam<T>(string storedProcName, SqlParameter[] procParams) where T : class
        {
            DbConnection conn = Context.Database.GetDbConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    await conn.OpenAsync();

                await using (DbCommand command = conn.CreateCommand())
                {
                    if (IsInTransaction())
                    {
                        command.Transaction = Context.Database.CurrentTransaction.GetDbTransaction();
                    }

                    command.CommandText = storedProcName;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(procParams);

                    DbDataReader reader = await command.ExecuteReaderAsync();

                    
                    List<T> objList = new List<T>();
                    IEnumerable<PropertyInfo> props = typeof(T).GetRuntimeProperties();
                    Dictionary<string, DbColumn> colMapping = reader.GetColumnSchema()
                        .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
                        .ToDictionary(key => key.ColumnName.ToLower());

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            T obj = Activator.CreateInstance<T>();
                            foreach (PropertyInfo prop in props)
                            {
                                object val =
                                    reader.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                                prop.SetValue(obj, val == DBNull.Value ? null : val);
                            }
                            objList.Add(obj);
                        }
                    }
                    reader.Dispose();

                    return objList;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message, e.InnerException);
            }
            finally
            {
                conn.Close();
            }

            return null; // default state
        }

        public async Task<T> ExecuteStoredProcObjectByParam<T>(string storedProcName, SqlParameter[] procParams) where T : class
        {
            DbConnection conn = Context.Database.GetDbConnection();

            try
            {
                if (conn.State != ConnectionState.Open)
                    await conn.OpenAsync();

                await using (DbCommand command = conn.CreateCommand())
                {
                    if (IsInTransaction())
                    {
                        command.Transaction = Context.Database.CurrentTransaction.GetDbTransaction();
                    }

                    command.CommandText = storedProcName;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(procParams);

                    DbDataReader reader = await command.ExecuteReaderAsync();

                    T obj = Activator.CreateInstance<T>();

                    if (reader.HasRows)
                    {
                        IEnumerable<PropertyInfo> props = typeof(T).GetRuntimeProperties();

                        Dictionary<string, DbColumn> colMapping = reader.GetColumnSchema()
                            .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
                            .ToDictionary(key => key.ColumnName.ToLower());

                        while (await reader.ReadAsync())
                        {
                            foreach (PropertyInfo prop in props)
                            {
                                object val =
                                    reader.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                                prop.SetValue(obj, val == DBNull.Value ? null : val);
                            }
                        }
                    }
                    else 
                    {
                        return null;
                    }
                    
                    reader.Dispose();

                    return obj;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message, e.InnerException);
            }
            finally
            {
                conn.Close();
            }

            return null; // default state
        }

        public async Task<int> ExecuteStoredProcReturnValue(string storedProcName, SqlParameter[] procParams)
        {
            int response = 0;
            DbConnection conn = Context.Database.GetDbConnection();
            try
            {
                if (conn.State != ConnectionState.Open)
                    await conn.OpenAsync();
                await using (DbCommand command = conn.CreateCommand())
                {
                    if (IsInTransaction())
                    {
                        command.Transaction = Context.Database.CurrentTransaction.GetDbTransaction();
                    }

                    command.CommandText = storedProcName;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(procParams);

                    DbDataReader reader = await command.ExecuteReaderAsync();

                    response = (int)command.Parameters["@onRespuesta"].Value;

                    reader.Dispose();

                    return response;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message, e.InnerException);
            }
            finally
            {
                conn.Close();
            }

            return response; // default state
        }
        public void ClearChangeTracker()
        {
            if (Context == null)
                return;

            Context.ChangeTracker.Clear();
        }

        public Task ExecuteInTransactionAsync(Func<Task> action)
        {
            var isAlreadyInTransaction = IsInTransaction();

            try
            {
                if (!isAlreadyInTransaction) BeginTransaction();
                action();
                if (!isAlreadyInTransaction) CommitTransaction();
            }
            catch (Exception)
            {
                if (!isAlreadyInTransaction)
                    RollbackTransaction();
                throw;
            }
            return Task.CompletedTask;
        }
    }

    public class UnitOfWork<T> : UnitOfWork, IUnitOfWork<T> where T : DbContext
    {
        #region Ctor

        public UnitOfWork(T dbContext)
            : base(dbContext)
        { }

        #endregion Ctor
    }
}
