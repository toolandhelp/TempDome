using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tool.Calendar.IServices.Base;

namespace Tool.Calendar.Services.Base
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseServices<T> : IBaseServices<T> where T : class, new()
    {
        public IBaseServices<T> baseDal;
        public async Task<bool> Add(T model)
        {
            return await baseDal.Add(model);
        }

        public async Task<bool> Delete(T model)
        {
            return await baseDal.Delete(model);
        }

        public async Task<bool> DeleteById(object objId)
        {
            return await baseDal.DeleteById(objId);
        }

        public async Task<bool> DeleteByIds(object[] lstIds)
        {
            return await baseDal.DeleteByIds(lstIds);
        }

        public async Task<List<T>> Query()
        {
            return await baseDal.Query();
        }
        public List<T> QueryWhere(Expression<Func<T, bool>> predicate)
        {
            return baseDal.QueryWhere(predicate);
        }
        public async Task<IEnumerable<T>> QueryById(Expression<Func<T, bool>> whereExpression)
        {
            return await baseDal.QueryById(whereExpression);
        }
        public async Task<List<T>> Query(Expression<Func<T, bool>> whereExpression)
        {
            return await baseDal.Query(whereExpression);
        }

        public async Task<List<T>> QueryOrder(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderByExpression, bool isAsc = true)
        {
            return await baseDal.QueryOrder(whereExpression, orderByExpression, isAsc);
        }

        public async Task<List<T>> QueryPage<TKey>(Expression<Func<T, bool>> whereExpression, Expression<Func<T, TKey>> orderByExpression, int intPageIndex, int intPageSize = 20, bool isAsc = true)
        {
            return await baseDal.QueryPage(whereExpression, orderByExpression, intPageIndex, intPageSize, isAsc);
        }

        public async Task<bool> Update(T model)
        {
            return await baseDal.Update(model);
        }
    }
}
