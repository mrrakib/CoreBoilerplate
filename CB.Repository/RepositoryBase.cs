using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepoContext _repositoryContext { get; set; }
        public RepositoryBase(RepoContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public void Create(T entity)
        {
            _repositoryContext.Set<T>().Add(entity);
            //_repositoryContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _repositoryContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return _repositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _repositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            _repositoryContext.Set<T>().Update(entity);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return _repositoryContext.Set<T>().Where(where).FirstOrDefault<T>();
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await _repositoryContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _repositoryContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> where)
        {
            return await _repositoryContext.Set<T>().Where(where).FirstOrDefaultAsync<T>();
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return _repositoryContext.Database.ExecuteSqlRaw(sqlCommand, parameters);
        }
        public IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters)
        {
            return _repositoryContext.Set<T>().FromSqlRaw(query, parameters);
        }
        public IEnumerable<T> ExecStoreProcedure<T>(string sql, params object[] parameters) where T : class
        {
            return _repositoryContext.Set<T>().FromSqlRaw(sql);
        }

        public IEnumerable<T> SQLQueryList<T>(string sql) where T : class
        {
            return _repositoryContext.Set<T>().FromSqlRaw(sql);
        }

        public T SQLQuery<T>(string sql) where T : class
        {
            return _repositoryContext.Set<T>().FromSqlRaw(sql).FirstOrDefault();
        }

        public T ExecuteScalar<T>(string sqlCommand, params object[] parameters) where T : class
        {
            return _repositoryContext.Set<T>().FromSqlRaw(sqlCommand).FirstOrDefault();
        }
        public bool IsExist(Expression<Func<T, bool>> predicate)
        {
            var count = _repositoryContext.Set<T>().Count(predicate);
            return count > 0;
        }
    }
}
