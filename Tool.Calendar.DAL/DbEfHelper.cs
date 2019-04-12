using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using Tool.Calendar.Model;

namespace Tool.Calendar.DAL
{
    public class DbEfHelper<T> : BaseServiceEf<CalendarBaseContext>, IRepository<T> where T : class, new()
    {

        private DbSet<T> DbQueryTracking
        {
            get
            {
                return _context.Set<T>();
            }
        }

        //private DbQuery<T> DbQueryNoTracking
        //{
        //    get
        //    {
        //        return _context.Set<T>().AsNoTracking();
        //    }
        //}

        public bool Add(T entity)
        {
            try
            {
                DbQueryTracking.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
               // MessageLog.AddErrorLogDbEfSql(typeof(T).ToString(), "Add:" + ex.Message);
                return false;
            }
        }

        public bool AddAll(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public bool PhysicalDelete(T entity)
        {
            throw new NotImplementedException();
        }

        public bool PhysicalDeleteAll(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public bool PhysicalDeleteByCondition(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IList<T> SearchByAll()
        {
            try
            {
                //return _context.SysUser.ToList();
                //return DbQueryNoTracking.ToList();
            }
            catch (ArgumentNullException ex)
            {
               // MessageLog.AddErrorLogDbEfSql(typeof(T).ToString(), "SearchByAll:" + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                //MessageLog.AddErrorLogDbEfSql(typeof(T).ToString(), "SearchByAll:" + ex.Message);
                return null;
            }
            throw new NotImplementedException();
        }

        public IList<T> SearchByPageCondition<TS>(Expression<Func<T, bool>> expression, bool isAsc, Expression<Func<T, TS>> orderLamdba, int iPageIndex, int iPageSize, ref int iTotalRecord)
        {
            throw new NotImplementedException();
        }

        public T SearchBySingle(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
            //try
            //{
            //    //First,返回序列中的第一条记录，如果没有记录，则引发异常
            //    //FirstOrDefault,返回序列中的第一条记录，如果序列中不包含任何记录，则返回默认值。
            //    //Single,返回序列中的唯一一条记录，如果没有或返回多条，则引发异常。
            //    //SingleOrDefault，返回序列中的唯一一条记录，如果序列中不包含任何记录，则返回默认值，如果返回多条，则引发异常。
            //    //注:以上默认值为NULL。
            //    var query = DbQueryNoTracking.FirstOrDefault(predicate);
            //    //MessageLog.AddErrorLogDbEfSql(typeof(T).ToString(), "SearchBySingle->SQL语句：",context.Log);
            //    return query;
            //}
            //catch (ArgumentNullException ex)
            //{
            //   // MessageLog.AddErrorLogDbEfSql(typeof(T).ToString(), "SearchBySingle:" + ex.Message);
            //    return null;
            //}
            //catch (Exception ex)
            //{
            //   // MessageLog.AddErrorLogDbEfSql(typeof(T).ToString(), "SearchBySingle:" + ex.Message);
            //    return null;
            //}
        }

        public IList<T> SearchListByCondition(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IList<T> SearchListByCondition<TS>(Expression<Func<T, bool>> expression, bool isAsc, Expression<Func<T, TS>> orderLamdba)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity, Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
