using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Dal.Bossdal;
using Dal.Selldal;
using Dal.Managerdal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ErpWebApi
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
            services.AddControllers();
            services.AddSingleton<IGoodsdal,Goodsdal>();
            services.AddSingleton<IUserinfodal,Userinfodal>();
            services.AddSingleton<IProducedal,Producedal>();
            services.AddSingleton<ISellDal,SellDal>();
            services.AddSingleton<IManagerD,ManagerDal>();
            services.AddCors(options =>
            {
                // Policy ���Q CorsPolicy ����ӆ�ģ������Լ���
                options.AddPolicy("getd", policy =>
                {
                    // �O�����S����ā�Դ���ж�����Ԓ������ `,` ���_
                    policy.WithOrigins("http://localhost:44370", "http://localhost:20343")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                });
            });
      
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
            app.UseCors("getd");
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
         

        }
    }
}
