using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace imammaturidi.org
{
    public class CustomConfigureServices
    {
        private WebApplicationBuilder _builder;
        private ConfigurationManager _configurationManager;

        public CustomConfigureServices(WebApplicationBuilder builder)
        {
            this._builder = builder;
            _configurationManager = builder.Configuration;
        }

        public void AddPostgreDbContext()
        {
            string connString = _configurationManager.GetConnectionString("QaSectionDB")!;
            _builder.Services.AddDbContext<DataAccess.EF.QaDbContext>(options =>
            {
                options.UseNpgsql(connString);
                if (_builder.Environment.EnvironmentName.Equals(Environments.Development))
                    options.LogTo(message => 
                        System.Diagnostics.Debug.WriteLine(message + "\n---------------------------------------------------")
                    ).EnableSensitiveDataLogging(true).EnableDetailedErrors();
            });    //dbcontext
        }

        public void AddControllersWithViews()
        {
            bool IsDevelopment = _builder.Environment.EnvironmentName.Equals(Environments.Development);
            if (IsDevelopment)
                _builder.Services
                    .AddControllersWithViews()
                    .AddRazorRuntimeCompilation()                   //cshtml editlemek için developmentta
                    .AddJsonOptions(x =>                            //Reference loop için
                            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            else
                _builder.Services
                    .AddControllersWithViews()
                    .AddJsonOptions(x =>                            //Reference loop için
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        }
    }
}
