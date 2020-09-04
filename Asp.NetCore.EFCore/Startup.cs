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
            ///ʹ��.NetCore��Ĭ��������
            
            ///
            services.AddControllersWithViews(); //MVC ����ע��
            services.AddSession();              //����session

            ///����ע��
            ///1.ע�������Ҫ�����������з���ȫ��ע�ᣩ
            ///2.ֱ���ڿ�������ͨ�����캯��ע��
            ///IOC����
            #region Service��ע��
            services.AddScoped<IUserService, UserService>();//�û�
            services.AddScoped<IRememberKeyService, RememberKeyService>();//��¼Session
            services.AddScoped<IMenuService, MenuService>();//�˵�
            services.AddScoped<ISendCarService, SendCarService>();//�ɳ�
            services.AddScoped<IContractService, ContractService>();//��ͬ
            services.AddScoped<IMaterialService, MaterialService>();//����
            services.AddScoped<ISendGroupService, SendGroupService>();//������λ
            services.AddScoped<IReceiveGroupService, ReceiveGroupService>();//�ջ���λ
            #endregion

            #region Dal��ע��
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
