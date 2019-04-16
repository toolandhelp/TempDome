using System;
using System.Collections.Generic;
using System.Text;
using Tool.Calendar.IRepository;
using Tool.Calendar.Models.Models;
using Tool.Calendar.Repository.Base;
using Tool.Calendar.Repository.MysqlEFCore;

namespace Tool.Calendar.Repository
{
    public class T_ConsumptionTypeRepository : BaseRepository<T_ConsumptionType>, IT_ConsumptionTypeRepository
    {
        public T_ConsumptionTypeRepository(MySqlDbContext context) : base(context)
        {

        }
    }
}
