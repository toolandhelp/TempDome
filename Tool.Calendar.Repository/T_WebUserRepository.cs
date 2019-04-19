using System;
using System.Collections.Generic;
using System.Text;
using Tool.Calendar.IRepository;
using Tool.Calendar.Models.Models;
using Tool.Calendar.Repository.Base;
using Tool.Calendar.Repository.MysqlEFCore;

namespace Tool.Calendar.Repository
{
    public class T_WebUserRepository : BaseRepository<T_WebUser>, IT_WebUserRepository
    {
        public T_WebUserRepository(MySqlDbContext context) : base(context)
        {

        }
    }
}
