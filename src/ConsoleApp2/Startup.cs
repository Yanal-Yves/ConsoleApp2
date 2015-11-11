namespace ConsoleApp2
{
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Hosting;
    using Microsoft.Data.Entity;
    using Microsoft.Framework.Configuration;
    using Microsoft.Framework.DependencyInjection;
    using Microsoft.Framework.Logging;

    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("config.json");
            configurationBuilder.AddJsonFile($"config.{env.EnvironmentName}.json", optional: true);
            configurationBuilder.AddEnvironmentVariables();
            this.Configuration = configurationBuilder.Build();
        }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
               .AddSqlServer()
               .AddDbContext<MyDbContext>(options =>
                   options.UseSqlServer(this.Configuration["Data:DefaultConnection:ConnectionString"]));

            // Uncomment the following line to add Web API services which makes it easier to port Web API 2 controllers.
            // You will also need to add the Microsoft.AspNet.Mvc.WebApiCompatShim package to the 'dependencies' section of project.json.
            // services.AddWebApiConventions();
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
        }
    }
}