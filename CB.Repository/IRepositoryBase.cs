using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        Task<IEnumerable<T>> FindAllAsync();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(Expression<Func<T, bool>> where);
        Task<T> GetAsync(Expression<Func<T, bool>> where);

        int ExecuteCommand(string sqlCommand, params object[] parameters);
        IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters);
        IEnumerable<T> ExecStoreProcedure<T>(string sql, params object[] parameters) where T : class;
        IEnumerable<T> SQLQueryList<T>(string sql) where T : class;
        T SQLQuery<T>(string sql) where T : class;
        bool IsExist(Expression<Func<T, bool>> predicate);
        T ExecuteScalar<T>(string sqlCommand, params object[] parameters) where T : class;
    }
}
