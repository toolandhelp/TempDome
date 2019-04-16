using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tool.Calendar.IServices.Base
{
    public interface IBaseServices<T> where T : class
    {
        Task<List<T>> Query();

        List<T> QueryWhere(Expression<Func<T, bool>> predicate);
        //Task<List<T>> Query(string strWhere);
        Task<IEnumerable<T>> QueryById(Expression<Func<T, bool>> whereExpression);

        Task<List<T>> Query(Expression<Func<T, bool>> whereExpression);

        //Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, string strOrderFileds);

        Task<List<T>> QueryOrder(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderByExpression, bool isAsc = true);

        Task<List<T>> QueryPage<TKey>(Expression<Func<T, bool>> whereExpression, Expression<Func<T, TKey>> orderByExpression, int intPageIndex, int intPageSize = 20, bool isAsc = true);

        //Task<List<T>> QueryById(object objId);

        //Task<T> QueryByIds(object[] lstIds);

        Task<bool> Add(T model);

        Task<bool> DeleteById(object objId);

        Task<bool> Delete(T model);

        Task<bool> DeleteByIds(object[] lstIds);

        Task<bool> Update(T model);
    }
}
