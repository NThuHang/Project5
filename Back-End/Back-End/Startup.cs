using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;
using DAL.Helper;
using Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Back_End
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            //var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    //IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddControllers();
            services.AddTransient<IDatabaseHelper, DatabaseHelper>();
            services.AddTransient<IDanhMucDAL, DanhMucDAL>();
            services.AddTransient<IDanhMucBLL, DanhMucBLL>();
            services.AddTransient<IGiangVienDAL, GiangVienDAL>();
            services.AddTransient<IGiangVienBLL, GiangVienBLL>();
            services.AddTransient<ITaiKhoanDAL, TaiKhoanDAL>();
            services.AddTransient<ITaiKhoanBLL, TaiKhoanBLL>();
            services.AddTransient<IQT_DaoTaoDAL, QT_DaoTaoDAL>();
            services.AddTransient<IQT_DaoTaoBLL, QT_DaoTaoBLL>();
            services.AddTransient<IQT_CongTacDAL, QT_CongTacDAL>();
            services.AddTransient<IQT_CongTacBLL, QT_CongTacBLL>();
            services.AddTransient<IBaoChiDAL, BaoChiDAL>();
            services.AddTransient<IBaoChiBLL, BaoChiBLL>();
            services.AddTransient<ILoai_TapChiDAL, Loai_TapChiDAL>();
            services.AddTransient<ILoai_TapChiBLL, Loai_TapChiBLL>();
            services.AddTransient<ITapChiDAL, TapChiDAL>();
            services.AddTransient<ITapChiBLL, TapChiBLL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
