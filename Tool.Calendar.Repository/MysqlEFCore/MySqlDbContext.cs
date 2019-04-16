using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tool.Calendar.Models.Models;

namespace Tool.Calendar.Repository.MysqlEFCore
{
    public class MySqlDbContext:DbContext
    {
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //注入Sql链接字符串
        //    optionsBuilder.UseMySQL(@"Data Source=192.168.10.20;Database=BlogDB;User ID=root;Password=!NotFind0bj;pooling=true;port=3306;sslmode=none;CharSet=utf8;");
        //}

        public DbSet<T_ConsumptionType> t_ConsumptionTypes { get; set; }
    }
}
