using MassTransit;
using MassTransit.Definition;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SignalRSampleService.Contexts;
using SignalRSampleService.Data;
using SignalRSampleService.Hubs.Hubs;
using SignalRSampleService.RabbitMq.Consumer;
using SignalRSampleService.RabbitMq.Producer;
using SignalRSampleService.Repositories;

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

            services.AddHealthChecks();

            services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);

            services.AddMassTransit(config =>
            {
                config.AddConsumer<OrderConsumer>();

                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host("amqp://guest:guest@rabbitmq:5672");

                    cfg.ReceiveEndpoint("order-queue", action =>
                    {
                        action.ConfigureConsumer<OrderConsumer>(ctx);
                    });
                });
            });

            services.AddMassTransitHostedService();

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
                        "http://localhost",
                        "http://aspnetcorereactreduxtemplate-env.eba-mcv635ym.eu-west-1.elasticbeanstalk.com"
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



            #region EFCore
            services.AddDbContext<ProjectDetailContext>(options => options.UseNpgsql
                (Configuration.GetSection("DatabaseSettings").GetConnectionString("DefaultConnection"))
            );

            services.AddDbContext<CompanyContext>(options => options.UseNpgsql
                (Configuration.GetConnectionString("DefaultConnection"))
            );
            #endregion

            #region Data repositories
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IProjectDetailRepository, ProjectDetailRepository>();
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

            /*

            var bus = Bus.Factory.CreateUsingRabbitMq(config =>
            {
                config.Host("amqp://guest:guest@rabbitmq");
                config.ReceiveEndpoint("temp-queue", action => {

                    action.Handler<Order>(ctx =>
                    {
                        return Console.Out.WriteLineAsync(ctx.Message.Name);
                    });
                
                });
            });

            bus.Start();

            bus.Publish(new Order { Name = "Test name " });

            */


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
