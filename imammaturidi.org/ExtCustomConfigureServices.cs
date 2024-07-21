using Business.Abstract;
using Business.Services;
using DataAccess;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace imammaturidi.org
{
    public static class ExtCustomConfigureServices
    {

        public static void ExtAddPostgreDbContext(this WebApplicationBuilder builder, ConfigurationManager configurationManager)
        {
            string connString = configurationManager.GetConnectionString("QaSectionDB")!;
            builder.Services.AddDbContext<DataAccess.EF.QaDbContext>(options =>
            {
                options.UseNpgsql(connString);
                if (builder.Environment.EnvironmentName.Equals(Environments.Development))
                    options.LogTo(message => 
                        System.Diagnostics.Debug.WriteLine(message + "\n---------------------------------------------------")
                    ).EnableSensitiveDataLogging(true).EnableDetailedErrors();
            });    //dbcontext
        }
        public static void ExtInjectDALServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUsersDAL, UsersDAL>();
        }

        public static void ExtInjectBLLServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserService, UserService>();
        }


        //ExtAddControllersWithViews metodu bu metoddan sonra çalıştırılmalıdır.
        public static void ExtAddCookieAuth(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = "/Account/Login"; // Kullanıcının yönlendirileceği login sayfası
                options.LogoutPath = "/Account/Logout";
                options.ExpireTimeSpan = TimeSpan.FromDays(14); // Cookie'nin geçerlilik süresi
                options.SlidingExpiration = true; // Yenileme süresi
            });
        }

        public static void ExtAddControllersWithViews(this WebApplicationBuilder builder)
        {
            bool IsDevelopment = builder.Environment.EnvironmentName.Equals(Environments.Development);
            if (IsDevelopment)
                builder.Services
                    .AddControllersWithViews()
                    .AddRazorRuntimeCompilation()                   //cshtml editlemek için developmentta
                    .AddJsonOptions(x =>                            //Reference loop için
                            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            else
                builder.Services
                    .AddControllersWithViews()
                    .AddJsonOptions(x =>                            //Reference loop için
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        }
    }
}
