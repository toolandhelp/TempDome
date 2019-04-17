using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using Tool.Calendar.Repository.MysqlEFCore;
using System.IO;

namespace Tool.Calendar.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region 连接字符串注入

            var connection = Configuration.GetConnectionString("MysqlConnection");
            services.AddDbContext<MySqlDbContext>(options => options.UseMySQL(connection));

            #endregion

            #region AutoMapper注入

            //services.AddAutoMapper(typeof(Startup));

            #endregion

            #region MiniProfiler性能分析注入

            services.AddMiniProfiler().AddEntityFramework();

            #endregion

            #region Swagger注入

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Version = "v0.1.0",
                    Title = "Tool.Calendar API",
                    Description="框架说明文档",
                    TermsOfService="None",
                    Contact=new Swashbuckle.AspNetCore.Swagger.Contact { Name= "Tool.Calendar",Email= "dengpengp@gmail.com",Url= "http://96.45.186.146" }
                });

                //添加读取xml文件里的注释

                //  var basePath= PlatformServices.Default.Application.ApplicationBasePath;
                var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "Tool.Calendar.Api.xml");
                c.IncludeXmlComments(xmlPath, true);//默认的第二个参数是false，这个是controller的注释，记得修改

                var xmlModelPath = Path.Combine(basePath, "Tool.Calendar.Models.xml");// 这是models层的xml文件名
                c.IncludeXmlComments(xmlModelPath, true);
            });


            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                #region Swagger 中间件 （也可写到此方法块外面）
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
                    c.RoutePrefix = ""; //路径配置，设置为空，表示直接访问文件
                                        //路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，
                                        //这个时候去launchSettings.json中把"launchUrl": "swagger/index.html"去掉， 然后直接访问localhost:8001/index.html即可

                });
                #endregion
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }
            #region MiniProfiler 中间件
            app.UseMiniProfiler();
            #endregion


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
