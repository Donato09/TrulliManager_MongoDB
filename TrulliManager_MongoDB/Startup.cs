using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrulliManager.Database;
using Microsoft.Extensions.Options;
using HotChocolate;
using HotChocolate.AspNetCore;
using TrulliManager.Repository.Abstract;
using TrulliManager.Repository.Concrete;

namespace TrulliManager_MongoDB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //MONGODB CONFIG 
            services.Configure<TrulliManagerDatabaseSettings>(
                Configuration.GetSection(nameof(TrulliManagerDatabaseSettings)));

            services.AddSingleton<ITrulliManagerDatabaseSettings>(provider =>
                provider.GetRequiredService<IOptions<TrulliManagerDatabaseSettings>>().Value);

            //services.AddTransient(typeof(DbContext), typeof(TrulliContext));
            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<ITrulloRepository, TrulloRepository>();

            services.AddInMemorySubscriptions();

            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<ITrulloRepository, TrulloRepository>();

            services.AddScoped<TrulliContext>();
            //services.AddScoped<TrulloType>();
            //services.AddScoped<PropertyType>();
            //services.AddScoped<Query>();
            //services.AddScoped<Mutation>();

            services
                .AddRouting()
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>()
                .AddFiltering()
                .AddSorting();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TrulliContext db)
        {
            if (env.IsDevelopment())
            {
                app.UsePlayground();
            }

            //preload db
            db.EnsureSeedData();

            app.UseWebSockets();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

        }
    }
}
