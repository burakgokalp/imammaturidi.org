using Microsoft.EntityFrameworkCore;


namespace imammaturidi.org
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            var conf = builder.Configuration;

            #region EKLEDİKLERİM
            string connString = conf.GetConnectionString("QaSectionDB")!;
            builder.Services.AddDbContext<DataAccess.EF.QaDbContext>(options =>
            {
                options.UseNpgsql(connString);
                if (builder.Environment.EnvironmentName.Equals(Environments.Development))
                    options.LogTo(message => System.Diagnostics.Debug.WriteLine(message + "\n---------------------------------------------------"))
                        .EnableSensitiveDataLogging(true)
                        .EnableDetailedErrors();
            });    //dbcontext
            #endregion EKLEDİKLERİM

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
