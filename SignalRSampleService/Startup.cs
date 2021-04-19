using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SignalRSampleService.Hubs.Hubs;
using SignalRSampleService.RabbitMq.Producer;

namespace SignalRSampleService
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

            #region MassTransit

            /*

            services.AddHealthChecks();

            services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);

            services.AddMassTransit(config =>
            {
                config.AddConsumer<OrderConsumer>();

                var rabbitMqSettings = Configuration.GetSection(nameof(RabbitMqSettings)).Get<RabbitMqSettings>();


                config.UsingRabbitMq((ctx, cfg) =>
                {
       
                    cfg.Host(rabbitMqSettings.Host);

                    cfg.ReceiveEndpoint("order-queue", action =>
                    {
                        action.ConfigureConsumer<OrderConsumer>(ctx);
                    });
                });
            });

            services.AddMassTransitHostedService();

            */

            #endregion

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SignalR Sample Service", Version = "v1" });
            });

            #region CORS setup
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder
                    .WithOrigins(
                        "http://localhost"
                    )
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    );
            });
            #endregion

            #region SignalR
            services.AddSignalR();
            #endregion

            #region Automapper
            services.AddAutoMapper(typeof(Startup));
            #endregion


            #region RabbitMQ dependencies
            services.AddScoped<IRabbitMqProducer, RabbitMqProducer>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Net5WebAPI v1"));
            }


            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ViewHub>("/hubs/view");
            });
        }
    }
}
