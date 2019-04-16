using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tool.Calendar.IRepository.Base;
using Tool.Calendar.Repository.MysqlEFCore;

namespace Tool.Calendar.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly MySqlDbContext db;

        internal MySqlDbContext dbContext { get; set; }

        internal DbSet<T> _dbSet;

        public BaseRepository(MySqlDbContext dbContext)
        {
            this.db = dbContext;
            this.dbContext = dbContext;
            _dbSet = db.Set<T>();
        }

        /// <summary>
        /// 添加一个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Add(T model)
        {
            await _dbSet.AddAsync(model);
            return await dbContext.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 根据实体删除 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Delete(T model)
        {
            _dbSet.Remove(model);
            return await dbContext.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteById(object objId)
        {
            var model = await _dbSet.FindAsync(objId);
            _dbSet.Remove(model);
            return await dbContext.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 根据一组ID批量删除
        /// </summary>
        /// <param name="lstIds"></param>
        /// <returns></returns>
        public async Task<bool> DeleteByIds(object[] lstIds)
        {
            var list = await _dbSet.FindAsync(lstIds);
            _dbSet.RemoveRange(list);
            return await dbContext.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> Query()
        {
            return await Task.Run(()=>_dbSet.ToList());
        }
        /// <summary>
        /// 根据Linq表达式条件查询
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<List<T>> Query(Expression<Func<T, bool>> whereExpression)
        {
            return whereExpression != null ? await Task.Run(() => _dbSet.Where(whereExpression).AsNoTracking().ToList()) : await Task.Run(() => _dbSet.AsQueryable<T>().AsNoTracking().ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> QueryById(Expression<Func<T, bool>> whereExpression)
        {
            return whereExpression != null ? await Task.Run(() => _dbSet.Where(whereExpression).AsNoTracking()) : await Task.Run(() => _dbSet.AsQueryable<T>().AsNoTracking());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereExpression">查询条件</param>
        /// <param name="orderByExpression">排序条件</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        public async Task<List<T>> QueryOrder(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderByExpression, bool isAsc = true)
        {
            if (isAsc)
            {
                return whereExpression != null ? await Task.Run(() => _dbSet.Where(whereExpression).OrderBy(orderByExpression).AsNoTracking().ToList()) : await Task.Run(() => _dbSet.AsNoTracking<T>().ToList());
            }
            return whereExpression != null ? await Task.Run(() => _dbSet.Where(whereExpression).OrderByDescending(orderByExpression).AsNoTracking().ToList()) : await Task.Run(() => _dbSet.AsNoTracking<T>().ToList());
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="whereExpression"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public async Task<List<T>> QueryPage<TKey>(Expression<Func<T, bool>> whereExpression, Expression<Func<T, TKey>> orderByExpression, int intPageIndex, int intPageSize = 20, bool isAsc = true)
        {
            int rowcount = _dbSet.Count(whereExpression);
            if (isAsc)
            {
                return await Task.Run(() => _dbSet.Where(whereExpression).OrderBy(orderByExpression).Skip((intPageIndex - 1) * intPageSize).Take(intPageSize).AsNoTracking().ToList());
            }
            return await Task.Run(() => _dbSet.Where(whereExpression).OrderByDescending(orderByExpression).Skip((intPageIndex - 1) * intPageSize).Take(intPageSize).AsNoTracking().ToList());
        }

        public List<T> QueryWhere(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public async Task<bool> Update(T model)
        {
            _dbSet.Update(model);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
