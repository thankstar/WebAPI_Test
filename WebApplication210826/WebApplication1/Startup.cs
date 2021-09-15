using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;

namespace WebApplication1
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
            //注册Swagger生成器，定义一个和多个Swagger 文档
            services.AddSwaggerGen(c =>
            {
               

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "系统 API", Version = "v1" });
              

                // 接口排序
                c.OrderActionsBy(o => o.GroupName + "," + o.HttpMethod + "," + o.RelativePath);
                //// 配置 xml 文档
                //var xmlFileLoacl = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPathLoacl = System.IO.Path.Combine(BaseDirectory, xmlFileLoacl);
                //c.IncludeXmlComments(xmlPathLoacl, true);


                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

             #region Swagger           
            //启用Swagger
            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "系统 API V1");
                // 访问Swagger的路由后缀
                c.RoutePrefix = "swagger";
            });
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
