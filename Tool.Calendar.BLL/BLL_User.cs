using System;
using System.Collections.Generic;
using System.Text;
using Tool.Calendar.DAL;
using Tool.Calendar.Model;

namespace Tool.Calendar.BLL
{
    public class BLL_User
    {
        #region dbContext
        public DbEfHelper<SysUser> dbContext { get; set; }
        public BLL_User()
        {
            dbContext = new DbEfHelper<SysUser>();
        }
        #endregion
        #region  查询 Search Entity


        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public IList<SysUser> GetListByAll()
        {
            return dbContext.SearchByAll();
        }

        /// <summary>
        /// 根据用户ID获取
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public SysUser GetObjectById(Guid gid)
        {
            return dbContext.SearchBySingle(c => c.UserGuid.Equals(gid.ToString()));
        }

        /// <summary>
        /// 登陆用户
        /// </summary>
        /// <param name="sUserName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        //public SysUser LoginUsers(string sUserName, string password)
        //{
        //    return dbContext.SearchBySingle(c => c.Account == sUserName && c.Password == password);
        //}


        #endregion
    }
}
