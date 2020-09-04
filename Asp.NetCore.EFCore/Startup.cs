using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.NetCore.Business.Interface;
using Asp.NetCore.Business.Service;
using Asp.NetCore.Dal;
using Asp.NetCore.DBFactory;
using Asp.NetCore.IDal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Asp.NetCore.EFCore
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
            ///使用.NetCore的默认容器：
            
            ///
            services.AddControllersWithViews(); //MVC 服务注册
            services.AddSession();              //配置session

            ///依赖注入
            ///1.注册服务（需要把依赖的所有服务全部注册）
            ///2.直接在控制器中通过构造函数注入
            ///IOC容器
            #region Service层注册
            services.AddScoped<IUserService, UserService>();//用户
            services.AddScoped<IRememberKeyService, RememberKeyService>();//记录Session
            services.AddScoped<IMenuService, MenuService>();//菜单
            services.AddScoped<ISendCarService, SendCarService>();//派车
            services.AddScoped<IContractService, ContractService>();//合同
            services.AddScoped<IMaterialService, MaterialService>();//物料
            services.AddScoped<ISendGroupService, SendGroupService>();//发货单位
            services.AddScoped<IReceiveGroupService, ReceiveGroupService>();//收货单位
            #endregion

            #region Dal层注册
            services.AddScoped<IUserDal, UserDal>();
            services.AddScoped<IMenuDal, MenuDal>();
            services.AddScoped<ISendCarDal, SendCarDal>();
            #endregion

            services.AddScoped<IDBContextFactory, DBContextFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSession();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
