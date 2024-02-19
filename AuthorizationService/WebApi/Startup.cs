using System.Text.Json.Serialization;
using Asp.Versioning;
using AutoMapper;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Services.Abstractions;
//using WebApi.Clients.ParkingService;
//using WebApi.Mapping;

namespace WebApi
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
            InstallAutomapper(services);
            services.AddServices(Configuration);
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                })
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressInferBindingSourcesForParameters = true;
                })
                .AddControllersAsServices(); ;

            services.AddCors();

            services.AddOcelot();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //services
            //    .AddEndpointsApiExplorer()
            //    .AddApiVersioning(options =>
            //    {
            //        options.AssumeDefaultVersionWhenUnspecified = true;
            //        options.DefaultApiVersion = new ApiVersion(1, 0);
            //    })
            //    .AddApiExplorer(options =>
            //    {
            //        options.GroupNameFormat = "'v'V";
            //        options.SubstituteApiVersionInUrl = true;
            //    });
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (!env.IsProduction())
            {
                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();
                
                // Configure the HTTP request pipeline.
                if (env.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
            }

            app.UseHttpsRedirection();

            await app.UseOcelot();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        
        private static IServiceCollection InstallAutomapper(IServiceCollection services)
        {
            return services;
        }
    }
    
}