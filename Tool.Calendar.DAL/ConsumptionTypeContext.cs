using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tool.Calendar.Model;

namespace Tool.Calendar.DAL
{
    public class ConsumptionTypeContext : DbContext
    {

        //https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/complex-data-model
        public ConsumptionTypeContext(DbContextOptions<ConsumptionTypeContext> options) : base(options)
        {
            //在此可对数据库连接字符串做加解密操作
        }

        public DbSet<ConsumptionType> Courses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
